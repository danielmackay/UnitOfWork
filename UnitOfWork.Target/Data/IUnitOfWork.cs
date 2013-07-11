using System;
using Uow.Target.Data.Repositories;

namespace Uow.Target.Data
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