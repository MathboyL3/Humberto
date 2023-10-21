using H1Store.Catalogo.Application.ViewModels;
using H1Store.Catalogo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1Store.Catalogo.Application.Interfaces
{
	public interface IProdutoService
	{
		IEnumerable<ProdutoViewModel> ObterTodos();
		Task<ProdutoViewModel> ObterPorId(Guid id);
		Task<IEnumerable<ProdutoViewModel>> ObterPorCategoria(int codigo);

		Task Adicionar(NovoProdutoViewModel produto);
		Task Desativar(Guid id);
		Task Atualizar(Guid id, NovoProdutoViewModel produto);
		public Task<ProdutoViewModel> ObterPorNome(string nome);
		public Task AlterarPreco(Guid id, decimal newPreco);
		public Task AtualizarEstoque(Guid id, int quantidade);
		public Task Ativar(Guid id);
	}
}
