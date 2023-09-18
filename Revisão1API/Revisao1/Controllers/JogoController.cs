using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Revisao1.Application.ViewModels;
using Revisao1.Domain.Entities;
using Revisao1.Domain.Interfaces.Services;
using Revisao1.Maps;

namespace Revisao1.Controllers
{
    [ApiController]
	[Route("[controller]")]
	public class JogoController : ControllerBase
	{
		IJogoService _jogoService { get; set; }
		public JogoController(IJogoService JogoService) 
		{
			_jogoService = JogoService;
		}


		[HttpPost]
		public ActionResult Post([FromBody] JogoViewModel model)
		{
			var mapper = AutoMapperConfiguration.config.CreateMapper();
			Jogo new_jogo = mapper.Map<Jogo>(model);

			if (!_jogoService.Add(new_jogo))
				return BadRequest("Jogo não registrado, os números devem ser diferentes!");

			return Ok("Jogo registrado com sucesso!");
		}

		[HttpGet]
		[Route("getall")]
		public IList<JogoViewModel> GetAll()
		{
			var mapper = AutoMapperConfiguration.config.CreateMapper();
			return mapper.Map<IList<JogoViewModel>>(_jogoService.GetAll());
		}

	}
}
