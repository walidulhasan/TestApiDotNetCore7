using Microsoft.EntityFrameworkCore;
using TestApi.Core;
using TestApi.Core.Repositories;
using TestApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TestApiDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("dbConnection")));
builder.Services.AddScoped<IUnitOfWork, UnitOfWorks>();
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
