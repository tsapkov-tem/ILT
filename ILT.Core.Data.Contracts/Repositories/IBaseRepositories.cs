using ILT.Core.Data.Entities.Models;

namespace ILT.Core.Data.Contracts.Repositories
{
    public interface IBaseRepositories<T> where T : IEntity
    {
        public T? GetById(string id);
        public T? GetByIdWithIncludedEntities(string id);
        public int Create(T entity);
        public int Update(T entity);
        public int Delete(T entity);
    }
}
