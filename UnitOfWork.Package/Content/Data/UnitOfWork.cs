using Uow.Package.Data.Repositories;

namespace Uow.Package.Data
{
    /// <summary>
    /// Unit of work provides access to repositories.  Operations on multiple repositories are atomic through
    /// the use of Commit().
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CustomerContext db = new CustomerContext();

        private ICustomerRepository customers;
        public ICustomerRepository Customers { get { return customers ?? (customers = new CustomerRepository(db)); } }

        /// <summary>
        /// Factoring method for starting a new UOW
        /// </summary>
        public static IUnitOfWork Begin()
        {
            return DataContainer.Resolve<IUnitOfWork>();
        }

        /// <summary>
        /// Commits changes made to all repositories
        /// </summary>
        public void Commit()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
