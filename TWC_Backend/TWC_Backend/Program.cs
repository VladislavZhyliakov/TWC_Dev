using Microsoft.EntityFrameworkCore;
using TWC_DatabaseLayer;
using TWC_DatabaseLayer.DTOs;
using TWC_DatabaseLayer.Mapper;
using TWC_DatabaseLayer.Models;
using TWC_Services.DBService;
using TWC_Services.HashService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("TWC_DB_Connection")));

builder.Services.AddScoped<IDBService, DBService>();
builder.Services.AddScoped<IHashService, HashService>();
builder.Services.AddScoped<IMapper<User, UserRegistrationDTO>, UserRegistrationMapper>();
builder.Services.AddScoped<IMapper<User, UserAuthenticationDTO>, UserAuthenticationMapper>();

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
