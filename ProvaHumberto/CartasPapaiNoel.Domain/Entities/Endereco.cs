using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartasPapaiNoel.Domain.Entities
{
	public class Endereco
	{
		public Endereco(string Rua, string Bairro, string Cidade, string Estado, int Numero) {
			this.Rua = Rua;
			this.Bairro = Bairro;
			this.Cidade = Cidade;
			this.Estado = Estado;
			this.Numero = Numero;
		}

		public string Rua { get; private set; }
		public string Bairro { get; private set; }
		public string Cidade { get; private set; }
		public string Estado { get; private set; }
		public int Numero { get; private set; }

		public string EnderecoCompleto()
		{
			return $"{Rua}, {Numero} - {Bairro} - {Cidade} - {Estado}";		
		}
	}
}
