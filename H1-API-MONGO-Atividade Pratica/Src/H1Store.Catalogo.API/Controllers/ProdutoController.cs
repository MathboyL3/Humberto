using H1Store.Catalogo.Application.Interfaces;
using H1Store.Catalogo.Application.ViewModels;
using H1Store.Catalogo.Data.Providers.MongoDb.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Xml.Linq;

namespace H1Store.Catalogo.API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ProdutoController : ControllerBase
	{
		private readonly IProdutoService _produtoService;
		public ProdutoController(IProdutoService produtoService)
		{
			_produtoService = produtoService;
		}

		[HttpPost]
		[Route("Adicionar")]
		public async Task<IActionResult> Adicionar(NovoProdutoViewModel novoProdutoViewModel)
		{
			await _produtoService.Adicionar(novoProdutoViewModel);

			return Ok();
		}

		[HttpPut]
		[Route("AtualizarEstoque/{id}/{quantidade}")]
		public async Task<IActionResult> AtualizarEstoque(Guid id, int quantidade)
		{
			await _produtoService.AtualizarEstoque(id, quantidade);

			return Ok($"Estoque modificado em {quantidade} com sucesso!");
		}

		[HttpPut]
		[Route("Atualizar/{id}")]

		public async Task<IActionResult> Atualizar(Guid id, [FromBody]NovoProdutoViewModel produto)
		{
			await _produtoService.Atualizar(id, produto);

			return Ok("Produto modificado com sucesso!");
		}

		[HttpPut]
		[Route("Desativar/{id}")]
		public async Task<IActionResult> Desativar(Guid id)
		{
			await _produtoService.Desativar(id);

			return Ok("Produto desativado com sucesso");
		}

		[HttpPut]
		[Route("Ativar/{id}")]
		public async Task<IActionResult> Ativar(Guid id)
		{
			await _produtoService.Ativar(id);

			return Ok("Produto ativado com sucesso");
		}

		[HttpGet]
		[Route("ObterPorNome/{nome}")]
		public async Task<IActionResult> ObterPorNome(string nome)
		{
			return Ok(await _produtoService.ObterPorNome(nome));
		}

		[HttpGet]
		[Route("ObterPorId/{id}")]
		public async Task<IActionResult> ObterPorId(Guid id)
		{
			return Ok(await _produtoService.ObterPorId(id));
		}

		[HttpPut]
		[Route("AlterarPreco/{id}/{preco}")]
		public async Task<IActionResult> AlterarPreco(Guid id, decimal preco)
		{
			await _produtoService.AlterarPreco(id, preco);
			return Ok("Preço alterado com sucesso!");
		}

		[HttpGet]
		[Route("ObterTodos")]
		public IActionResult GetAll()
		{
			return Ok(_produtoService.ObterTodos());
		}
	}
}
