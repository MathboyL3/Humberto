namespace APIProdutos.Domain.Interfaces.Repositories
{
	public interface IRepositoryBase<TEntity> where TEntity : class
	{
		public bool Add(TEntity entity);
		public TEntity Get(int id);
		public IList<TEntity> GetAll();
		public bool Update(int id, TEntity entity);
		public bool Remove(int id);
		public bool Save(IList<TEntity> entities);
	}
}
