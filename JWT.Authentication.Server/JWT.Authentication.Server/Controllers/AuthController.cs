using JWT.Authentication.Server.Core.Contract.Repository;
using JWT.Authentication.Server.Core.Entities;
using JWT.Authentication.Server.Infrastructure.Extensions;
using JWT.Authentication.Server.Infrastructure.VM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JWT.Authentication.Server.Controllers
{
    [Route("auth")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class AuthController : ControllerBase
    {
        private readonly IEmployeeRepository _userRepository;
        private readonly IConfiguration _config;
        public AuthController(IEmployeeRepository userRepository,IConfiguration configuration)
        {
            _userRepository = userRepository;
            _config = configuration;
        }

        [Route("register")]
        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<ActionResult> Register( EmployeeVm employee)
        {
            var passwordSalt = GenerateSalt();
            employee.Password += passwordSalt;
            var passwordHash = GenerateHashPassword(employee.Password);
            Employee user = new()
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Contact = employee.Contact,
                EmailId = employee.EmailId,
                Address = employee.Address,
                Salary = employee.Salary,
                DepartmentId = employee.DepartmentId,
                RoleId = employee.RoleId,
                Password = passwordHash,
                PasswordSalt = passwordSalt
            };
            var emplyeeData = await _userRepository.RegisterUser(user);
            return Ok(emplyeeData);
        }

        [HttpPost]
        [Route("login")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<ActionResult> Login(LoginVm userVm)
        {
            var user = await _userRepository.GetUserDetails(userVm.EmailId);
            if (user is null)
                return BadRequest("Invalid Email address or Password");
            userVm.Password += user.PasswordSalt;
            var passwordHash = GenerateHashPassword(userVm.Password);
            if (passwordHash == user.Password)
            {
                var roleName = await _userRepository.GetEmployeeRole(user);
                if(roleName is not null) { 
                var token = GenerateToken(user, roleName);
                return Ok(token);
                }
                return BadRequest("Role not found!");
            }
            return BadRequest("Invalid Email address or Password");
        }

        private string GenerateHashPassword(string password)
        {
            string machineKey = _config["MachineKey"].ToString();
            var hmac = new HMACSHA1()
            {
                Key = machineKey.HexToByte()
            };
            return Convert.ToBase64String(hmac.ComputeHash(password.GetByteArray()));
        }

        private static string GenerateSalt()
        {
            int saltLength = 8;
            byte[] salt = new byte[saltLength];
            using (var random = new RNGCryptoServiceProvider())
            {
                random.GetNonZeroBytes(salt);
            }
            return Convert.ToBase64String(salt);
        }
        string role;
        private string GenerateToken(Employee user,Role roleName)
        {
            var claims = new[]
            {
                new Claim("EmployeeId", user.EmployeeId.ToString()),
                new Claim("FirstName", user.FirstName),
                new Claim("LastName", user.LastName),
                new Claim("EmailId", user.EmailId),
                new Claim("Role", roleName.RoleName),
                new Claim(ClaimTypes.Role,roleName.RoleName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(3),
                signingCredentials: signIn);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
