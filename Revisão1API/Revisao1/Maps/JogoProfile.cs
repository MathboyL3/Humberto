using AutoMapper;
using Revisao1.Application.ViewModels;
using Revisao1.Domain.Entities;

namespace Revisao1.Maps
{
	public class JogoProfile : Profile
	{
		public JogoProfile() {
			CreateMap<JogoViewModel, Jogo>();
			CreateMap<Jogo, JogoViewModel>();
		}
	}
}
