using APIProdutos.Application.ViewModel;
using APIProdutos.AutoMapperConfiguration;
using APIProdutos.Domain.Entities;
using APIProdutos.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIProdutos.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ProdutoController : ControllerBase
	{
		private IProdutoService _service { get; set; }

		public ProdutoController(IProdutoService service) => _service = service;

		#region CRUD

		// Create
		[HttpPost]
		public IActionResult Create([FromBody] ProdutoViewModel produto)
		{
			var new_produto = AutoMapperConfig.Mapper.Map<Produto>(produto);
			return _service.Add(new_produto) ? Ok("Produto criado com sucesso!") : BadRequest("Falha ao criar produto!");
		}


		// Read
		[HttpGet("{id}")]
		public ProdutoViewModel GetOne(int id)
		{
			var produto = _service.Get(id);
			return AutoMapperConfig.Mapper.Map<ProdutoViewModel>(produto);
		}

		[HttpGet]
		public IList<ProdutoViewModel> GetAll()
		{
			var produtos = _service.GetAll();
			return AutoMapperConfig.Mapper.Map<IList<ProdutoViewModel>>(produtos);
		}


		// Update
		[HttpPut("{id}")]
		public IActionResult Update(int id, [FromBody] ProdutoViewModel produto)
		{
			var new_produto = AutoMapperConfig.Mapper.Map<Produto>(produto);
			return _service.Update(id, new_produto) ? Ok("Produto atualizado com sucesso!") : BadRequest("Falha ao atualizar produto!");
		}


		// Delete
		[HttpDelete("{id}")]
		public IActionResult Remove(int id)
		{
			return _service.Remove(id) ? Ok("Produto removido com sucesso!") : BadRequest("Falha ao remover produto!");
		}

		#endregion
	}
}
