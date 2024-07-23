using ILT.Core.Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILT.Core.Data.Contracts.Services
{
    public interface IBaseService<T> where T : IEntity
    {
        public T Get(string id);
        public T Create(T entity);
        public T Update(T entity);
        public T Delete(string id);

    }
}
