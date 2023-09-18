using APIProdutos.Application.ViewModel;
using APIProdutos.AutoMapperConfiguration;
using APIProdutos.Domain.Entities;
using APIProdutos.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace APIProdutos.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class FornecedorController : ControllerBase
	{
		private IFornecedorRepository _service { get; set; }

		public FornecedorController(IFornecedorRepository service) => _service = service;

		#region CRUD

		// Create
		[HttpPost]
		public IActionResult Create([FromBody] FornecedorViewModel produto)
		{
			var new_produto = AutoMapperConfig.Mapper.Map<Fornecedor>(produto);
			return _service.Add(new_produto) ? Ok("Fornecedor criado com sucesso!") : BadRequest("Falha ao criar fornecedor!");
		}


		// Read
		[HttpGet("{id}")]
		public FornecedorViewModel GetOne(int id)
		{
			var produto = _service.Get(id);
			return AutoMapperConfig.Mapper.Map<FornecedorViewModel>(produto);
		}

		[HttpGet]
		public IList<FornecedorViewModel> GetAll()
		{
			var fornecedores = _service.GetAll();
			return AutoMapperConfig.Mapper.Map<IList<FornecedorViewModel>>(fornecedores);
		}


		// Update
		[HttpPut("{id}")]
		public IActionResult Update(int id, [FromBody] FornecedorViewModel fornecedor)
		{
			var new_fornecedor = AutoMapperConfig.Mapper.Map<Fornecedor>(fornecedor);
			return _service.Update(id, new_fornecedor) ? Ok("Fornecedor atualizado com sucesso!") : BadRequest("Falha ao atualizar fornecedor!");
		}


		// Delete
		[HttpDelete("{id}")]
		public IActionResult Remove(int id)
		{
			return _service.Remove(id) ? Ok("Fornecedor removido com sucesso!") : BadRequest("Falha ao remover fornecedor!");
		}

		#endregion
	}
}
