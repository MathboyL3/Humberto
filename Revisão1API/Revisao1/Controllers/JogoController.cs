using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Revisao1.Domain.Entities;
using Revisao1.Domain.Interfaces;
using Revisao1.Maps;
using Revisao1.ViewModels;

namespace Revisao1.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class JogoController : ControllerBase
	{
		IService<Jogo> _jogoService { get; set; }
		public JogoController(IService<Jogo> JogoService) 
		{
			_jogoService = JogoService;
		}


		[HttpPost]
		public ActionResult PostJogo([FromBody] JogoViewModel model)
		{
			Jogo new_jogo = new Jogo()
			{
				CPF = model.CPF,
				Date = DateTime.Now,
				Nome = model.Nome,
				Numero1 = model.Numero1,
				Numero2 = model.Numero2,
				Numero3 = model.Numero3,
				Numero4 = model.Numero4,
				Numero5 = model.Numero5,
				Numero6 = model.Numero6,
			};

			if (!_jogoService.AddJogo(new_jogo))
				return BadRequest("Jogo não registrado, os números devem ser diferentes!");

			return Ok("Jogo registrado com sucesso!");
		}

		[HttpGet]
		[Route("getall")]
		public IList<JogoViewModel> GetAll()
		{
			var mapper = AutoMapperConfiguration.config.CreateMapper();
			return mapper.Map<IList<JogoViewModel>>(_jogoService.GetJogos());
		}

	}
}
