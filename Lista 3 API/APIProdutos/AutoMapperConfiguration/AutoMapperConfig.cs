using AutoMapper;
using APIProdutos.AutoMapperConfiguration.Profiles;
namespace APIProdutos.AutoMapperConfiguration
{
	public static class AutoMapperConfig
	{
		public static MapperConfiguration Configuration { get; private set; }
		public static IMapper Mapper => Configuration.CreateMapper();
		public static void Configure()
		{
			Configuration = new MapperConfiguration(config =>
				{
					config.AddProfile<ViewModelToDomain>();
					config.AddProfile<DomainToViewModel>();
				});
		}
	}
}
