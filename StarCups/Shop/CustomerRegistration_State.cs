using System.Collections.Generic;
using StarCups.Shop.Events;

namespace StarCups.Shop
{
    internal class CustomerRegistration_State
    {
        public readonly List<CustomerReference> Customers;

        public CustomerRegistration_State(List<object> history)
        {
            Customers = new List<CustomerReference>();
            foreach (var @event in history)
            {
                Apply(@event);
            }
        }

        private void Apply(object e)
        {
            if (e is Customer_registered) Apply((Customer_registered)e);
        }

        private void Apply(Customer_registered e) => Customers.Add(e.Customer);
    }
}