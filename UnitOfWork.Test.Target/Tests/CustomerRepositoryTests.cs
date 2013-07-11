using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Uow.Target.Data;
using Uow.Test.Target.Utilities;

namespace Uow.Test.Target.Tests
{
    [TestClass]
    public class CustomerRepositoryTests : TestBase
    {
        [TestMethod]
        public void CanAddCustomer()
        {
            // Ensure we have a fresh DB
            InitDb();

            // Real test against the DB
            using (var uow = UnitOfWork.Begin())
            {
                var customer = EntityFactory.Customer;
                uow.Customers.Create(customer);
                uow.Commit();
            }

            using (var db = new CustomerContext())
            {
                // Counts the Customers actually in the DB
                db.Customers.Count().ShouldBeEquivalentTo(1);
            }
        }

        [TestMethod]
        public void CanGetCustomersByName()
        {
            // Mock GetByName() in the CustomerRepository
            var mock = Substitute.For<IUnitOfWork>();
            var customers = EntityFactory.Customers;
            mock.Customers.GetByName("").ReturnsForAnyArgs(customers.AsQueryable());
            DataContainer.RegisterInstance(mock);

            using (var uow = UnitOfWork.Begin())
            {
                // Does not hit the DB, and returns what we've told it to
                uow.Customers.GetByName("foo").Should().HaveCount(2);
            }
        }
    }
}
