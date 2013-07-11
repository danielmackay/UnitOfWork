using Microsoft.Practices.Unity;

namespace Uow.Package.Data
{
    /// <summary>
    /// IoC container for storing data types/instances
    /// </summary>
    public class DataContainer
    {
        public static UnityContainer Container { get; private set; }

        static DataContainer()
        {
            Container = new UnityContainer();
            InitDefaults();
        }

        public static void RegisterType<TInterface, TClass>() where TClass : TInterface
        {
            Container.RegisterType<TInterface, TClass>();
        }

        public static void RegisterInstance<TInterface>(TInterface instance)
        {
            Container.RegisterInstance(instance);
        }

        public static TInterface Resolve<TInterface>()
        {
            return Container.Resolve<TInterface>();
        }

        private static void InitDefaults()
        {
            RegisterType<IUnitOfWork, UnitOfWork>();
        }
    }
}