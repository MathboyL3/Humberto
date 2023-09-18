using APIProdutos.Application.Services;
using APIProdutos.AutoMapperConfiguration;
using APIProdutos.Data.Repositories;
using APIProdutos.Domain.Interfaces.Repositories;
using APIProdutos.Domain.Interfaces.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IProdutoRepository, ProdutoRepository>();
builder.Services.AddTransient<IFornecedorRepository, FornecedorRepository>();
builder.Services.AddTransient<ICategoriaRepository, CategoriaRepository>();

builder.Services.AddTransient<IProdutoService, ProdutoService>();
builder.Services.AddTransient<IFornecedorService, FornecedorService>();
builder.Services.AddTransient<ICategoriaService, CategoriaService>();

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
