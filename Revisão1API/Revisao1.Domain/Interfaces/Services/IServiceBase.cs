using Revisao1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revisao1.Domain.Interfaces.Services
{
    public interface IServiceBase<T>
    {
        public bool Add(T entity);
        public IList<T> GetAll();
        public T GetByID(int id);
    }
}
