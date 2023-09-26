using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartasPapaiNoel.Domain.Entities
{
	public class Carta : IEntityBase
	{
		private Carta() { }
		public Carta(int ID, string Nome, Endereco Endereco, int Idade, string Conteudo) {
			this.ID = ID;
			this.Nome = Nome;
			this.Endereco = Endereco;
			this.Idade = Idade;
			this.Conteudo = Conteudo;
		}

		public int ID { get; private set; }

		public string Nome { get; private set; }
		public Endereco Endereco { get; private set; }
		public int Idade { get; private set; }
		public string Conteudo { get; private set; }

		public int GetNextID(IList<IEntityBase> entities)
		{
			return ID = entities.Count > 0 ? entities.Max(e => e.ID) + 1 : 0;
		}
	}
}
