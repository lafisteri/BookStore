using System.Reflection;
using BusinessLayer.BooksService;
using BusinessLayer.Mapper;
using DataLayer.BooksRepository;
using DataLayer.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IBooksService, BooksService>();
builder.Services.AddScoped<IBooksRepository, BooksRepository>();

builder.Services.AddDbContext<MySqlContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));

var assemblies = new[]
    {
        Assembly.GetAssembly(typeof(BookProfile))
    };
builder.Services.AddAutoMapper(assemblies);

builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAll", builder =>
            builder.AllowAnyOrigin()   // For testing
                   .AllowAnyMethod()   // For testing
                   .AllowAnyHeader()); // For testing
    });

var app = builder.Build();

app.UseCors("AllowAll"); // For testing

app.MapGet("/", () => "It is alive!!");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
