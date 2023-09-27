using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartasPapaiNoel.Application.ViewModels
{
	public class EnderecoViewModel
	{
		[Required]
		public string Rua { get; set; }
		[Required]
		public string Bairro { get; set; }
		[Required]
		public string Cidade { get; set; }
		[Required]
		public string Estado { get; set; }
		[Required]
		public int Numero { get; set; }
	}
}
