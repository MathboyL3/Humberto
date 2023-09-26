using CartasPapaiNoel.Domain.Entities;
using CartasPapaiNoel.Domain.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartasPapaiNoel.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : IEntityBase
    {
        protected string CartasFolder { get; set; }
        protected string CartasPath { get; set; }
        public RepositoryBase() { }

        public bool Delete(int id)
        {
            var cartas = GetAll();
            for (int i = 0; i < cartas.Count; i++)
            {
                if (cartas[i].ID == id)
                {
                    cartas.RemoveAt(i);
                    return Save(cartas);
                }
            }
            return false;
        }
		public bool Add(TEntity entity)
		{
			var cartas = GetAll();
            entity.GetNextID(cartas.Select(c =>(IEntityBase)c).ToList());
			cartas.Add(entity);
			Save(cartas);
			return true;
		}

		public IList<TEntity> GetAll()
        {
            if (!File.Exists(CartasPath)) return new List<TEntity>();

            string json = File.ReadAllText(CartasPath);
            return JsonConvert.DeserializeObject<List<TEntity>>(json);
        }

        public TEntity GetEntity(int id)
        {
            return GetAll().FirstOrDefault(c => c.ID == id);
        }

        public bool Save(IList<TEntity> entities)
        {
            Directory.CreateDirectory(CartasFolder);
            File.WriteAllText(CartasPath, JsonConvert.SerializeObject(entities));
            return true;
        }

        public bool Update(int id, TEntity entity)
        {
            var cartas = GetAll();
            for (int i = 0; i < cartas.Count; i++)
            {
                if (cartas[i].ID == id)
                {
                    cartas[i] = entity;
                    return Save(cartas);
                }
            }
            return false;
        }
    }
}
