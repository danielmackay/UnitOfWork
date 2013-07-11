using System.Data.Entity;
using System.Linq;
using Uow.Package.Models;

namespace Uow.Package.Data.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<Customer> GetByName(string name)
        {
            return DbSet.Where(c => c.Name.Contains(name));
        }
    }
}