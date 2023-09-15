using Revisao1.Application.Services;
using Revisao1.Data.JogoR;
using Revisao1.Domain.Entities;
using Revisao1.Domain.Interfaces;
using Revisao1.Domain.Interfaces.Repositories;
using Revisao1.Domain.Interfaces.Services;
using Revisao1.Maps;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IJogoService, JogoService>();
builder.Services.AddTransient<IJogoRepository, JogoRepository>();

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

AutoMapperConfiguration.Configure();

app.Run();
