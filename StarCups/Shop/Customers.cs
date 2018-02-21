using System;
using StarCups.Shop.Events;

namespace StarCups.Shop
{
    internal class CustomerRegistration
    {
        private readonly Action<object> publish;
        private readonly CustomerRegistration_State state;

        public CustomerRegistration(CustomerRegistration_State state, Action<object> publish)
        {
            this.publish = publish;
            this.state = state;
        }

        public void Register(CustomerReference customer, string name, string familyname)
        {
            if (!state.Customers.Contains(customer))
                publish(new Customer_registered(customer, name, familyname));
        }
    }
}