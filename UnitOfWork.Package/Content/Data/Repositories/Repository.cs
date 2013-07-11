using System.Data.Entity;
using System.Linq;

namespace Uow.Package.Data.Repositories
{
    // TODO: Add more base functionality
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbSet<T> DbSet;

        public Repository(DbContext dbContext)
        {
            DbSet = dbContext.Set<T>();
        }

        public T GetById(int id)
        {
            return DbSet.Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return DbSet.AsQueryable();
        }

        public void Create(T entity)
        {
            DbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }
    }
}