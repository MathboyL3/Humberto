using APIProdutos.Application.ViewModel;
using APIProdutos.Domain.Entities;
using AutoMapper;

namespace APIProdutos.AutoMapperConfiguration.Profiles
{
	public class DomainToViewModel : Profile
	{
		public DomainToViewModel()
		{
			CreateMap<Produto, ProdutoViewModel>();
			CreateMap<Fornecedor, FornecedorViewModel>();
			CreateMap<Categoria, CategoriaViewModel>();
		}
	}
}
