using System.Linq;
using Uow.Package.Models;

namespace Uow.Package.Data.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        IQueryable<Customer> GetByName(string name);
    }
}