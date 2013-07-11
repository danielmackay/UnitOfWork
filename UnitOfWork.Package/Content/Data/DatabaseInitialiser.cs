using System.Data.Entity;

namespace Uow.Package.Data
{
    /// <summary>
    /// Creates the DB if it doesn't exist and populates it with seed data
    /// </summary>
    public class DatabaseInitialiser : CreateDatabaseIfNotExists<CustomerContext>
    {
        protected override void Seed(CustomerContext context)
        {
            // TODO: Add your seed data here
        }
    }
}