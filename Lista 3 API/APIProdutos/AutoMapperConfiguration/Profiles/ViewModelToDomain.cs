using APIProdutos.Application.ViewModel;
using APIProdutos.Domain.Entities;
using AutoMapper;

namespace APIProdutos.AutoMapperConfiguration.Profiles
{
	public class ViewModelToDomain : Profile
	{
		public ViewModelToDomain() {
			CreateMap<ProdutoViewModel, Produto>();
			CreateMap<FornecedorViewModel, Fornecedor>();
			CreateMap<CategoriaViewModel, Categoria>();
		}
	}
}
