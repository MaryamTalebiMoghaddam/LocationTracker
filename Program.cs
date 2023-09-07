using LocationTracker.Data.Contracts;
using LocationTracker.Data.Repository;
using LocationTracker.Hubs;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.SignalR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IGeoCoordinateRepository, GeoCoordinateRepository>();
builder.Services.AddScoped<SignalRHub>();
builder.Services.AddScoped<ILocationHub,LocationHub>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();
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
app.MapHub<SignalRHub>("/LocationHub");
app.Run();
