using System;
using StarCups.Shop;
using StarCups.Shop.Commands;
using StarCups.Shop.Events;
using StarCups.Shop.Information;
using StarCups.Shop.Queries;
using StarCups.Shop.References;

namespace StarCups_Specs.Shop
{
    public partial class CustomerRegistration_Specs
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

        private Customer_registration_denied Customer_registration_denied(CustomerReference customer, Reason reason)
        {
            return new Customer_registration_denied(customer, reason);
        }

        private Number_of_customers NumberOfCustomers()
        {
            return new Number_of_customers();
        }

        private Customer_Names Customer_Names()
        {
            return new Customer_Names();
        }
    }
}