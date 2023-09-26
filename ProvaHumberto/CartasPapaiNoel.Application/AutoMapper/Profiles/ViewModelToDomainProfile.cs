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
	public class ViewModelToDomainProfile : Profile
	{
		public ViewModelToDomainProfile()
		{
			CreateMap<EnderecoViewModel, Endereco>();
			CreateMap<CartaViewModel, Carta>();
		}
	}
}
