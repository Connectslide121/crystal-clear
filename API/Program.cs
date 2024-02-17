using DatabaseConnection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

IConfigurationRoot Configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

// Get the connection string from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("CrystalClearConnection");

// Set the MySQL Server Version
var serverVersion = new MySqlServerVersion(new Version(8, 0, 35));

// Configure the DbContext with the connection string
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, serverVersion));

//Connect Interfaces to Services
builder.Services.AddScoped<ICitiesService, CitiesService>();
builder.Services.AddScoped<IQuotesService, QuotesService>();


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
