using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revisao1.Domain.Entities
{
	public class Jogo
	{
		public string Nome { get; set; }
		public string CPF { get; set; }
		public int ID { get; set; }
		public DateTime Date { get; set; }
		public int Numero1 { get; set; }
		public int Numero2 { get; set; }
		public int Numero3 { get; set; }
		public int Numero4 { get; set; }
		public int Numero5 { get; set; }
		public int Numero6 { get; set; }

		public bool IsNumerosValidos()
		{
			if (Numero1 != Numero2 && Numero1 != Numero3 && Numero1 != Numero4 && Numero1 != Numero5 && Numero1 != Numero6 &&
				Numero2 != Numero3 && Numero2 != Numero4 && Numero2 != Numero5 && Numero2 != Numero6 &&
				Numero3 != Numero4 && Numero3 != Numero5 && Numero3 != Numero6 &&
				Numero4 != Numero5 && Numero4 != Numero6 &&
				Numero5 != Numero6) return true;
			return false;
		}
	}
}
