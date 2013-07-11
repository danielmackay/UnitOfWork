using System.Collections.Generic;
using Uow.Target.Models;

namespace Uow.Test.Target.Utilities
{
    /// <summary>
    /// Factory containing mock data to be used by unit tests
    /// </summary>
    public static class EntityFactory
    {
        public static Customer Customer
        {
            get
            {
                return new Customer()
                {
                    Name = "Dan",
                    Age = 25
                };
            }
        }

        public static List<Customer> Customers
        {
            get
            {
                return new List<Customer>
                {
                    new Customer()
                    {
                        Name = "Dan",
                        Age = 25
                    },
                    new Customer()
                    {
                        Name = "Fred",
                        Age = 30
                    }
                };
            }
        }
    }
}