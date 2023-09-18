using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revisao1.Domain.Entities
{
	public class Jogo
	{
		#region construtores
		public Jogo(string Nome, string CPF, int Numero1, int Numero2, int Numero3, int Numero4, int Numero5, int Numero6) {
			this.Nome = Nome;
			this.CPF = CPF;
			this.Numero1 = Numero1;
			this.Numero2 = Numero2;
			this.Numero3 = Numero3;
			this.Numero4 = Numero4;
			this.Numero5 = Numero5;
			this.Numero6 = Numero6;

			this.Date = DateTime.Now;
		}
		#endregion


		#region propriedades

		public string Nome { get; private set; }
		public string CPF { get; private set; }
		public int ID { get; private set; }
		public DateTime Date { get; private set; }
		public int Numero1 { get; private set; }
		public int Numero2 { get; private set; }
		public int Numero3 { get; private set; }
		public int Numero4 { get; private set; }
		public int Numero5 { get; private set; }
		public int Numero6 { get; private set; }

		#endregion


		#region comportamentos

		public bool IsNumerosValidos()
		{
			if (Numero1 != Numero2 && Numero1 != Numero3 && Numero1 != Numero4 && Numero1 != Numero5 && Numero1 != Numero6 &&
				Numero2 != Numero3 && Numero2 != Numero4 && Numero2 != Numero5 && Numero2 != Numero6 &&
				Numero3 != Numero4 && Numero3 != Numero5 && Numero3 != Numero6 &&
				Numero4 != Numero5 && Numero4 != Numero6 &&
				Numero5 != Numero6) return true;
			return false;
		}

		public void UpdateNextID(IList<Jogo> jogos)
		{
			ID = jogos.Count > 0 ? jogos.Max(x => x.ID) : 0;
		}

		public void RegisterTimeNow()
		{
			Date = DateTime.Now;
		}

		#endregion
	}
}
