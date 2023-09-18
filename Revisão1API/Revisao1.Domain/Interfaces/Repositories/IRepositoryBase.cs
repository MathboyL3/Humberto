using Revisao1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revisao1.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<T>
    {
        public bool Add(T jogo);
        public T Get(int id);
        public IList<T> GetAll();
    }
}
