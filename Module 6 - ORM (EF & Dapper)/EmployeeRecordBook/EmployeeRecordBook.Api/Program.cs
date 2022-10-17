using AutoMapper;
using EmployeeRecordBook.Api.Configurations;
using EmployeeRecordBook.Api.Extensions;
using EmployeeRecordBook.Infrastructure.Data;
using EmployeeRecordBook.Infrastructure.Repositories;
using EmployeeRecordBook.Infrastructure.Repositories.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

#region Configure and Register AutoMapper
var config = new MapperConfiguration(config => config.AddProfile(new AutoMapperProfile()));
IMapper mapper = config.CreateMapper();
builder.Services.AddSingleton<IMapper>(mapper);
#endregion

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.RegisterSystemService();
builder.Services.RegisterApplicatinService();

var app = builder.Build();

app.CreateMiddlewarePipeline();

app.Run();
