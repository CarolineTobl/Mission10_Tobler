using Microsoft.EntityFrameworkCore;
using Mission10_ToblerAPI.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BowlingDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("BowlingLeagueConnection")));
builder.Services.AddScoped<IBowlingRepository, EFBowlingRepository>();
builder.Services.AddCors();
builder.Services.AddControllers();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(p => p
    .WithOrigins("http://localhost:3000") // React development server
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
