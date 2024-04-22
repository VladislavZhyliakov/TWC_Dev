using Microsoft.EntityFrameworkCore;
using TWC_DatabaseLayer;
using TWC_DatabaseLayer.DTOs;
using TWC_Services.Mapper;
using TWC_DatabaseLayer.Models;
using TWC_Services.HashService;
using TWC_Services.DBService.Interfaces;
using TWC_Services.DBService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("TWC_DB_Connection")));

builder.Services.AddScoped<IDBUserService, DBUserService>();
builder.Services.AddScoped<IDBProjectService, DBProjectService>();
builder.Services.AddScoped<IDBPasswordSaltService, DBPasswordSaltService>();
builder.Services.AddScoped<IHashService, HashService>();
builder.Services.AddScoped<IMapper<User, UserRegistrationDTO>, UserRegistrationMapper>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors();

app.MapControllers();

app.Run();
