using EmployeeRecordBook.Infrastructure.Data;
using EmployeeRecordBook.Infrastructure.Repositories;
using EmployeeRecordBook.Infrastructure.Repositories.EntityFramework;

var builder = WebApplication.CreateBuilder(args);



#region System Service Registration
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EmployeeContext>();
#endregion


#region Application Service Registration
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
