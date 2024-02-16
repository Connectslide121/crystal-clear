using DatabaseConnection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Get the connection string from the environment variable
//var connectionString = Environment.GetEnvironmentVariable("CrystalClearConnection");
var connectionString = "server=localhost;port=3306;database=crystalclear;user=root;password=Mendi1987;";


// Set the MySQL Server Version
var serverVersion = new MySqlServerVersion(new Version(8, 0, 35));

// Configure the DbContext with the connection string
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, serverVersion));


//Connect IDataService to DataService
//builder.Services.AddScoped<IUsersService, UsersService>();
//builder.Services.AddScoped<IPostsService, PostsService>();
//builder.Services.AddScoped<IEventsService, EventsService>();
//builder.Services.AddScoped<ICommentsService, CommentsService>();







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
