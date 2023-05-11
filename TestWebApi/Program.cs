using BAL.Service;
using DAL.DataAccess;
using DAL.DBContext;
using DAL.IDataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Get DB Path from Data Access Layer (DAL) in Database directory.
var dbPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "DAL\\Database");

//string path = Path.Combine(Directory.GetCurrentDirectory(), "App_Data");

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection").Replace("[DataDirectory]", dbPath)));
builder.Services.AddTransient<ITemprature, Temprature>();
builder.Services.AddTransient<IUnitConverstionService, UnitConverstionService>();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "AspNetCore5WebApiService", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
