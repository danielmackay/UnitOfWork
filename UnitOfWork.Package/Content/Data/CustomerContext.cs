using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Uow.Package.Models;

namespace Uow.Package.Data
{
    public class CustomerContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        static CustomerContext()
        {
            Database.SetInitializer(new DatabaseInitialiser());
        }

        /// <summary>
        /// Update Created and Modified timestamps for all new/updated entities
        /// </summary>
        /// <returns></returns>
        public override int SaveChanges()
        {
            var objectContext = ((IObjectContextAdapter)this).ObjectContext;
            var newEntities = objectContext.ObjectStateManager
                .GetObjectStateEntries(EntityState.Added | EntityState.Modified)
                .Where(e => e.Entity is Entity);

            foreach (var e in newEntities)
            {
                var newEntity = (Entity)e.Entity;
                if (newEntity == null)
                    continue;

                if (e.State == EntityState.Added)
                    newEntity.Created = DateTime.Now;

                if (e.State == EntityState.Modified)
                    newEntity.Modified = DateTime.Now;
            }

            return base.SaveChanges();
        }
    }
}