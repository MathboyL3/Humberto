using CartasPapaiNoel.Domain.Entities;
using CartasPapaiNoel.Domain.Interfaces;
using CartasPapaiNoel.Domain.Interfaces.Specialized;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartasPapaiNoel.Application.Services
{
	public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : IEntityBase
	{
		protected IRepositoryBase<TEntity> _repository { get; set; }

		public ServiceBase(IRepositoryBase<TEntity> repository)
		{
			_repository = repository;
		}

		public bool Add(TEntity entity)
		{
			return _repository.Add(entity);
		}

		public bool Delete(int id)
		{
			return _repository.Delete(id);
		}

		public IList<TEntity> GetAll()
		{
			return _repository.GetAll();
		}

		public TEntity GetEntity(int id)
		{
			return _repository.GetEntity(id);
		}

		public bool Save(IList<TEntity> entities)
		{
			return _repository.Save(entities);
		}

		public bool Update(int id, TEntity entity)
		{
			return _repository.Update(id, entity);
		}
	}
}
