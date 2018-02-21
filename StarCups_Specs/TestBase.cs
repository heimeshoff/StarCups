using System.Collections.Generic;
using FluentAssertions;
using StarCups;

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
}