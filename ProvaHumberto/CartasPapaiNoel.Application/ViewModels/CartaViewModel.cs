using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartasPapaiNoel.Application.ViewModels
{
	public class CartaViewModel
	{
		public string Nome { get; set; }
		public EnderecoViewModel Endereco { get; set; }
		public int Idade { get; set; }
		public string Conteudo { get; set; }

	}
}
