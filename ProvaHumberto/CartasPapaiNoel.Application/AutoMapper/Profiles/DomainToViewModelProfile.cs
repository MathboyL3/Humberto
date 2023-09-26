using AutoMapper;
using CartasPapaiNoel.Application.ViewModels;
using CartasPapaiNoel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartasPapaiNoel.Application.AutoMapper.Profiles
{
	public class DomainToViewModelProfile : Profile
	{
		public DomainToViewModelProfile() {
			CreateMap<Endereco, EnderecoViewModel>();
			CreateMap<Carta, CartaViewModel>();
		}
	}
}
