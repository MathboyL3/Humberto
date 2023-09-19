using APIProdutos.Domain.Entities;

namespace APIProdutos.Domain.Interfaces
{
	public abstract class EntityBase
	{
		public virtual int ID { get; protected set; }

		public virtual int SetNextID(IList<EntityBase> list) => ID = list.Count > 0 ? list.Max(i => i.ID) + 1 : 0;
	}
}
