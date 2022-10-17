using JWT.Authentication.Server.Core.Contract.Repository;
using JWT.Authentication.Server.Core.Models;
using JWT.Authentication.Server.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JWT.Authentication.Server.Infrastructure.Extensions
{
    public static class ServiceCollectionExtenions
    {
        public static void AddConfigurationServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region Register Repository
            services.AddTransient<IEmployeeRepository, UserRepository>();
            #endregion

            #region Database
            services.AddScoped<EmployeemanagementDbContext>()
                     .AddDbContextPool<EmployeemanagementDbContext>(options =>
                     {
                         options.UseSqlServer(configuration.GetConnectionString("EmployeeDbContext"));
                     });
            #endregion

        }
    }
}
