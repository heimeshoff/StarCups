using System.Collections.Generic;
using StarCups.Shop.Events;

namespace StarCups.Shop.Readmodels
{
    internal class CustomersInformation_Readmodel
    {
        private int _count;
        private readonly List<string> _names;

        public CustomersInformation_Readmodel(List<object> history)
        {
            _count = 0;
            _names = new List<string>();

            history.ForEach(Apply);
        }
        
        private void Apply(object e)
        {
            if (e is Customer_registered) Apply((Customer_registered)e);
        }

        private void Apply(Customer_registered e)
        {
            _count++;
            _names.Add(e.Name);
        }

        public int Count() => _count;
        public string[] Names() => _names.ToArray();
    }
}
