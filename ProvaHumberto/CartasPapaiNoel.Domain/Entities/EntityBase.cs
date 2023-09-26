using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartasPapaiNoel.Domain.Entities
{
	public interface IEntityBase
	{
		public int ID { get; }

		public int GetNextID(IList<IEntityBase> entities);
	}
}
