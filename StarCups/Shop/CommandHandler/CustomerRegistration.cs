using System;
using StarCups.Shop.Events;
using StarCups.Shop.Information;
using StarCups.Shop.Readmodels;
using StarCups.Shop.References;

namespace StarCups.Shop.CommandHandler
{
    internal class CustomerRegistration
    {
        private readonly Action<object> publish;
        private readonly CustomerRegistration_State all_customers;

        public CustomerRegistration(CustomerRegistration_State all_customers, Action<object> publish)
        {
            this.publish = publish;
            this.all_customers = all_customers;
        }

        public void Register(CustomerReference customer, string name, string familyname)
        {
            if (!all_customers.Result().Contains(customer))
            {
                publish(new Customer_registered(customer, name, familyname));
            }
            else
            {
                publish(new Customer_registration_denied(customer, Reason.Already_registered));
            }
        }
    }
}