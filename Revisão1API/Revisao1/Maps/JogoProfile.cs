using AutoMapper;
using Revisao1.Domain.Entities;
using Revisao1.ViewModels;

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
