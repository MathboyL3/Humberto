namespace APIProdutos.Domain.Interfaces.Services
{
	public interface IServiceBase<TEntity> where TEntity : class
	{
		public bool Add(TEntity entity);
		public TEntity Get(int id);
		public IList<TEntity> GetAll();
		public bool Update(int id, TEntity entity);
		public bool Remove(int id);
	}
}
