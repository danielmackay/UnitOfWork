using System;
using Uow.Package.Data.Repositories;

namespace Uow.Package.Data
{
    /// <summary>
    /// Unit of work provides access to repositories.  Operations on multiple repositories are atomic through
    /// the use of Commit().
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository Customers { get; }
        void Commit();
    }
}