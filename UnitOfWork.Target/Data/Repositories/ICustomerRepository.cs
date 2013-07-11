using System.Linq;
using Uow.Target.Models;

namespace Uow.Target.Data.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        IQueryable<Customer> GetByName(string name);
    }
}