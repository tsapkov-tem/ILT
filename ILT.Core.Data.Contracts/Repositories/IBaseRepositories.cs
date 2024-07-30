using ILT.Core.Data.Entities.Models;

namespace ILT.Core.Data.Contracts.Repositories
{
    internal interface IBaseRepositories<T> where T : IEntity
    {
        T? GetById(string id);
        int Create(T entity);
        int Update(T entity);
        int Delete(T entity);
    }
}
