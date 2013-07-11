using Uow.Target.Data;

namespace Uow.Test.Target.Utilities
{
    /// <summary>
    /// Base class that provides functionality for tearing down and creating a new DB
    /// </summary>
    public abstract class TestBase
    {
        protected TestBase()
        {
            // Default to using the real UOW
            DataContainer.RegisterType<IUnitOfWork, UnitOfWork>();
        }

         protected void InitDb()
         {
             using (var db = new CustomerContext())
             {
                 if (db.Database.Exists())
                     db.Database.Delete();

                 db.Database.Create();
             }
         }
    }
}