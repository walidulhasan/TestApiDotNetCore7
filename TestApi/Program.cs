using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using TestApi.Core;
using TestApi.Core.Repositories;
using TestApi.Data;
using TestApi.Interface.Repositories.Orders;
using TestApi.InterfaceImplementation.Repositories.Orders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<TestApiDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("dbConnection")));
builder.Services.AddScoped<IUnitOfWork, UnitOfWorks>();
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
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
