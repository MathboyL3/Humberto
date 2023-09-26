using CartasPapaiNoel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CartasPapaiNoel.Domain.Interfaces
{
	public interface IRepositoryBase<TEntity> where TEntity : IEntityBase
	{
		public TEntity GetEntity(int id);
		public IList<TEntity> GetAll();
		public bool Add(TEntity entity);
		public bool Save(IList<TEntity> entities);
		public bool Delete(int id);
		public bool Update(int id, TEntity entity);
	}
}
