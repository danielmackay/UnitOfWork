using System.Linq;

namespace Uow.Target.Data.Repositories
{
    public interface IRepository<T>
    {
        T GetById(int id);
        void Create(T entity);
        void Delete(T entity);
        IQueryable<T> GetAll();
    }
}