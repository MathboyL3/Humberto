using CartasPapaiNoel.Application.AutoMapper.Configuration;
using CartasPapaiNoel.Application.ViewModels;
using CartasPapaiNoel.Domain.Entities;
using CartasPapaiNoel.Domain.Interfaces.Specialized;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CartasPapaiNoel.API.Controllers
{
	public class CartasController : ControllerBase
	{
		const string Pasta = "./Data/";
		const string CartasPath = $"{Pasta}Cartas.json";
		public IList<Carta> GetAllCartas()
		{
			if (!System.IO.File.Exists(CartasPath)) return new List<Carta>();

			string json = System.IO.File.ReadAllText(CartasPath);
			return JsonConvert.DeserializeObject<List<Carta>>(json);
		}

		public void SaveCartas(IList<Carta> cartas)
		{
			System.IO.File.WriteAllText(CartasPath, JsonConvert.SerializeObject(cartas));
		}

		public CartasController() { }

		[HttpGet]
		public IList<CartaViewModel> GetCartas()
		{
			return AutoMapperConfig.Map.Map<IList<CartaViewModel>>(GetAllCartas());
		}

		[HttpGet("{id}")]
		public CartaViewModel Get(int id)
		{
			return AutoMapperConfig.Map.Map<CartaViewModel>(GetAllCartas().FirstOrDefault(c => c.ID == id));
		}

		public ActionResult EnviarCarta([FromBody] CartaViewModel carta)
		{
			var cartas = GetAllCartas();
			var new_carta = AutoMapperConfig.Map.Map<Carta>(carta);
			cartas.Add(new_carta);
			SaveCartas(cartas);
			return Ok();
		}

	}
}
