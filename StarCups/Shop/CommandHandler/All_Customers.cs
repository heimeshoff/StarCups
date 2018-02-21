using System.Collections.Generic;
using StarCups.Shop.Events;
using StarCups.Shop.References;

namespace StarCups.Shop.CommandHandler
{
    internal class CustomerRegistration_State
    {
        private readonly List<CustomerReference> _customers;
        public List<CustomerReference> Result() => _customers;

        public CustomerRegistration_State(List<object> history)
        {
            _customers = new List<CustomerReference>();
            history.ForEach(Apply);
        }
        
        private void Apply(object e)
        {
            if (e is Customer_registered) Apply((Customer_registered)e);
        }

        private void Apply(Customer_registered e) => _customers.Add(e.Customer);
    }
}