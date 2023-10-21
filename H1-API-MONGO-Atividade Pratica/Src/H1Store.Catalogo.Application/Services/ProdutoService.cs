using AutoMapper;
using H1Store.Catalogo.Application.Interfaces;
using H1Store.Catalogo.Application.ViewModels;
using H1Store.Catalogo.Domain.Entities;
using H1Store.Catalogo.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1Store.Catalogo.Application.Services
{
	public class ProdutoService : IProdutoService
	{
		#region - Construtores
		private readonly IProdutoRepository _produtoRepository;
		private IMapper _mapper;

		public ProdutoService(IProdutoRepository produtoRepository, IMapper mapper)
		{
			_produtoRepository = produtoRepository;
			_mapper = mapper;
		}
		#endregion

		#region - Funções
		public async Task Adicionar(NovoProdutoViewModel novoProdutoViewModel)
		{
			var novoProduto = _mapper.Map<Produto>(novoProdutoViewModel);
			await _produtoRepository.Adicionar(novoProduto);

		}

		public async Task Desativar(Guid id)
		{
			var buscaProduto = await _produtoRepository.ObterPorId(id);

			if(buscaProduto == null)  throw new ApplicationException("Não é possível desativar um produto inexistente!");

			buscaProduto.Desativar();

			await _produtoRepository.Desativar(buscaProduto);

		}

		public async Task<IEnumerable<ProdutoViewModel>> ObterPorCategoria(int codigo)
		{
			return _mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoRepository.ObterPorCategoria(codigo));

		}

		public async Task<ProdutoViewModel> ObterPorId(Guid id)
		{
			return _mapper.Map<ProdutoViewModel>(await _produtoRepository.ObterPorId(id));
		}

		public IEnumerable<ProdutoViewModel> ObterTodos()
		{
			return _mapper.Map<IEnumerable<ProdutoViewModel>>(_produtoRepository.ObterTodos());
		}
		#endregion

		public async Task Atualizar(Guid id, NovoProdutoViewModel produto)
		{
			var prod = _mapper.Map<Produto>(produto);
			prod.CodigoId = id;
			await _produtoRepository.Atualizar(prod);
		}

		public async Task<ProdutoViewModel> ObterPorNome(string nome)
		{
			return _mapper.Map<ProdutoViewModel>(await _produtoRepository.ObterPorNome(nome));
		}

		public async Task AlterarPreco(Guid id, decimal newPreco)
		{
			var produto = await _produtoRepository.ObterPorId(id);
			
			if(produto == null) throw new ArgumentNullException("Produto não existente!");
			if(newPreco <= 0) throw new ArgumentNullException("O preço não não pode ser <= 0");

			await _produtoRepository.AlterarPreco(produto, newPreco);
		}
		public async Task AtualizarEstoque(Guid id, int quantidade)
		{
			var buscaProduto = await _produtoRepository.ObterPorId(id);
			if(quantidade > 0)
				buscaProduto.ReporEstoque(quantidade);
			else
				buscaProduto.DebitarEstoque(quantidade * -1);

			await _produtoRepository.AtualizarEstoque(buscaProduto);

		}

		public async Task Ativar(Guid id)
		{
			var produto = await _produtoRepository.ObterPorId(id);
			produto.Ativar();
			await _produtoRepository.Ativar(produto);
		}
	}
}
