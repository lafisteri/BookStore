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

var app = builder.Build();

app.MapGet("/", () => "It is alive!!");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
