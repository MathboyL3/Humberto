using AutoMapper;
using CartasPapaiNoel.Application.AutoMapper.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartasPapaiNoel.Application.AutoMapper.Configuration
{
	public static class AutoMapperConfig
	{
		public static MapperConfiguration Config { get; private set; }
		public static IMapper Map { get => Config.CreateMapper(); }

		public static void Configure()
		{
			Config = new MapperConfiguration(e => {
				e.AddProfile<DomainToViewModelProfile>();
				e.AddProfile<ViewModelToDomainProfile>();
			});
		}
	}
}
