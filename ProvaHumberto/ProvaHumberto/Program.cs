using CartasPapaiNoel.Application.AutoMapper.Configuration;
using CartasPapaiNoel.Application.Services;
using CartasPapaiNoel.Data.Repositories;
using CartasPapaiNoel.Domain.Interfaces.Specialized;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ICartaService, CartaService>();
builder.Services.AddTransient<ICartaRepository, CartaRepository>();

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
AutoMapperConfig.Configure();
app.Run();
