namespace APIProdutos.Domain.Interfaces
{
	public interface IIdentifiable
	{
		public int ID { get; }

		/// <summary>
		/// Sets the next available ID based on all existent IIdentifiables passed as list
		/// </summary>
		/// <param name="list"></param>
		/// <returns>The next available ID</returns>
		public int SetNextID(IList<IIdentifiable> list);
	}
}
