using System;
using StarCups.Shop.Commands;
using StarCups.Shop.Events;
using StarCups.Shop.References;

namespace StarCups_Specs.Shop
{
    public partial class Customer_Specs
    {
        private object Register_customer(CustomerReference customer, string name, string familyname)
        {
            return new Register_customer(customer, name, familyname);
        }

        private CustomerReference NewCustomer()
        {
            return new CustomerReference(Guid.NewGuid());
        }

        private Customer_registered Customer_registered(CustomerReference customer, string name, string familyname)
        {
            return new Customer_registered(customer, name, familyname);
        }
    }
}