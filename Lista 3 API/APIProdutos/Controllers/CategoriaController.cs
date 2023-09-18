using APIProdutos.Application.ViewModel;
using APIProdutos.AutoMapperConfiguration;
using APIProdutos.Domain.Entities;
using APIProdutos.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace APIProdutos.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CategoriaController : ControllerBase
	{
		private ICategoriaRepository _service { get; set; }

		public CategoriaController(ICategoriaRepository service) => _service = service;

		#region CRUD

		// Create
		[HttpPost]
		public IActionResult Create([FromBody] CategoriaViewModel produto)
		{
			var new_produto = AutoMapperConfig.Mapper.Map<Categoria>(produto);
			return _service.Add(new_produto) ? Ok("Categoria criada com sucesso!") : BadRequest("Falha ao criar categoria!");
		}


		// Read
		[HttpGet("{id}")]
		public CategoriaViewModel GetOne(int id)
		{
			var produto = _service.Get(id);
			return AutoMapperConfig.Mapper.Map<CategoriaViewModel>(produto);
		}

		[HttpGet]
		public IList<CategoriaViewModel> GetAll()
		{
			var fornecedores = _service.GetAll();
			return AutoMapperConfig.Mapper.Map<IList<CategoriaViewModel>>(fornecedores);
		}


		// Update
		[HttpPut("{id}")]
		public IActionResult Update(int id, [FromBody] CategoriaViewModel fornecedor)
		{
			var new_fornecedor = AutoMapperConfig.Mapper.Map<Categoria>(fornecedor);
			return _service.Update(id, new_fornecedor) ? Ok("Categoria atualizado com sucesso!") : BadRequest("Falha ao atualizar categoria!");
		}


		// Delete
		[HttpDelete("{id}")]
		public IActionResult Remove(int id)
		{
			return _service.Remove(id) ? Ok("Categoria removido com sucesso!") : BadRequest("Falha ao remover categoria!");
		}

		#endregion
	}
}
