using AutoMapper;
namespace Revisao1.Maps
{
	public class AutoMapperConfiguration
	{
		public static MapperConfiguration config { get; private set; }
		public static void Configure()
		{
			config = new MapperConfiguration(cfg => 
				cfg.AddProfile<JogoProfile>()
			);
		}
	}
}
