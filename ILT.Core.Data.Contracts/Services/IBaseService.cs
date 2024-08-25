using ILT.Core.Data.Entities.Models;

namespace ILT.Core.Data.Contracts.Services
{
    public interface IBaseService<T> where T : IEntity
    {
        public T? Get(string id);
        public T? GetByIdWithIncludedEntities(string id);
        public T Create(T entity);
        public T Update(T entity);
        public void Delete(string id);

    }
}
