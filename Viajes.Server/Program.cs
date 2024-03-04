using Microsoft.EntityFrameworkCore;
using Viajes.Server.Controllers;
using Viajes.Server.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbviajesContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("conexionBD"));
});

builder.Services.AddHttpClient();

builder.Services.AddCors(options => options.AddPolicy(name: "viajes.client",
    policy =>
    {
        policy.WithOrigins("*"
                            )
                            .AllowAnyHeader()
                            .AllowAnyMethod();
    }));

var app = builder.Build();

app.UseCors("viajes.client");
app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
