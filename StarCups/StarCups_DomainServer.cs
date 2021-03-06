using System;
using System.Collections.Generic;
using StarCups.Shop;
using StarCups.Shop.CommandHandler;
using StarCups.Shop.Commands;
using StarCups.Shop.Readmodels;

namespace StarCups
{
    public class StarCups_DomainServer
    {
        private readonly Action<object> _publish;

        public StarCups_DomainServer(Action<object> publish)
        {
            _publish = publish;
        }

        public void Handle(object command, List<object> history)
        {
            if (command is Register_customer customer) Handle(customer, history);
        }

        private void Handle(Register_customer c, List<object> history)
        {
            var state = new CustomerRegistration_State(history);
            var customers = new CustomerRegistration(state, _publish);
            customers.Register(
                c.Customer,
                c.Name,
                c.Familyname);
        }
    }
}