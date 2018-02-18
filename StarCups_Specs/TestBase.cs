using System;
using System.Collections.Generic;
using FluentAssertions;
using StarCups.Shop.Commands;
using StarCups.Shop.Events;
using StarCups.Shop.References;

namespace StarCups_Specs
{
    public abstract class TestBase
    {
        private List<object> _history;
        private List<object> _actual_events;

        protected void Given(List<object> events)
        {
            _history = events;
        }

        protected void When(object command)
        {
            _actual_events = new List<object>();
            var starcups_service = 
                new StarCups_Service(
                    (@event) => _actual_events.Add(@event));
            starcups_service.Handle(command, _history);
        }

        protected void Then_expect(object expected_events)
        {
            _actual_events.Should().BeEquivalentTo(expected_events);
        }

        protected List<object> Nothing_happened_so_far()
        {
            return new List<object>();
        }
    }

    public class StarCups_Service
    {
        private readonly Action<object> _publish;

        public StarCups_Service(Action<object> publish)
        {
            _publish = publish;
        }

        public void Handle(object command, List<object> history)
        {
            if (command is Register_customer customer) Handle(customer, history);
        }

        private void Handle(Register_customer c, List<object> history)
        {
            var customers = new Customers(history, _publish);
            customers.Register(
                c.Customer,
                c.Name,
                c.Familyname);
        }
    }

    internal class Customers
    {
        private readonly List<object> _history;
        private readonly Action<object> _publish;
        private CustomerReference _id;
        private List<CustomerReference> _customers;

        public Customers(List<object> history, Action<object> publish)
        {
            _history = history;
            _publish = publish;
            _customers = new List<CustomerReference>();
            foreach (var @event in history)
            {
                Apply(@event);
            }
        }

        private void Apply(object e)
        {
            if (e is Customer_registered) Apply((Customer_registered) e);
        }

        private void Apply(Customer_registered e) => _customers.Add(e.Customer);

        public void Register(CustomerReference customer, string name, string familyname)
        {
            if (!_customers.Contains(customer))
                _publish(new Customer_registered(customer, name, familyname));
        }
    }
}