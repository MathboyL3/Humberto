using APIProdutos.Domain.Entities;
using APIProdutos.Domain.Interfaces;
using APIProdutos.Domain.Interfaces.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIProdutos.Data.Repositories
{
	public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class, IIdentifiable
	{
		public abstract string db_path { get; protected set; }

		public bool Add(TEntity entity)
		{
			var entities = GetAll();
			entities.Add(entity);
			return Save(entities);
		}

		public TEntity? Get(int id)
		{
			return GetAll().FirstOrDefault(p => p.ID.Equals(id));
		}

		public IList<TEntity> GetAll()
		{
			if (!File.Exists(db_path)) return new List<TEntity>();

			string json = File.ReadAllText(db_path);
			return JsonConvert.DeserializeObject<List<TEntity>>(json) ?? new List<TEntity>();
		}

		public bool Remove(int id)
		{
			var entities = GetAll();
			for (int i = 0; i < entities.Count; i++)
				if (entities[i].ID.Equals(id))
					entities.RemoveAt(i);
			return Save(entities);
		}
		public bool Update(int id, TEntity entity)
		{
			var entities = GetAll();
			for (int i = 0; i < entities.Count; i++)
				if (entities[i].ID.Equals(id))
					entities[i] = entity;
			return Save(entities);
		}

		public bool Save(IList<TEntity> entities)
		{
			try
			{
				Directory.CreateDirectory(db_path.Substring(0, db_path.LastIndexOf('\\') + 1));
				string json = JsonConvert.SerializeObject(entities);
				File.WriteAllText(db_path, json);
				return true;
			}
			catch(Exception e)
			{
				throw e;
				return false;
			}
		}
	}
}
