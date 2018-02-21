using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using StarCups;

namespace StarCups_Specs
{
    // TBD:
    // Full API Tests
    // Notifications
    // On the fly state changes in Domain
    // Logging -> Chain of Command
    // Persistence
    // UI
    // Messaging


    public abstract class TestBase
    {
        private List<object> _history;
        private List<object> _actual_events;

        protected void Given(params object[] events)
        {
            _history = events.ToList();
            _actual_events = new List<object>();
        }

        protected void When(object command)
        {
            var starcups_service = 
                new StarCups_DomainServer(
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

        protected object Query(object query)
        {
            var events = 
                _history
                .Concat(_actual_events)
                .ToList();

            var starcups_data = new StarCups_DataServer(events);
            return starcups_data.Query(query);
        }

    }
}