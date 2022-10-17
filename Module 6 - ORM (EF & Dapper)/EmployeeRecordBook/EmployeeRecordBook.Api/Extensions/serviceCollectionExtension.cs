using EmployeeRecordBook.Infrastructure.Data;
using EmployeeRecordBook.Infrastructure.Repositories;
using EmployeeRecordBook.Infrastructure.Repositories.EntityFramework;

namespace EmployeeRecordBook.Api.Extensions
{
    public static class serviceCollectionExtension
    {
        public static void RegisterSystemService(this IServiceCollection services)
        {

            // Add services to the container.
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDbContext<EmployeeContext>();
        }
        public static void RegisterApplicatinService(this IServiceCollection services)
        {
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();

        }
    }
}
