using System;
using System.Collections.Generic;
using StarCups.Shop.Queries;
using StarCups.Shop.Readmodels;

namespace StarCups
{
    public class StarCups_DataServer
    {
        private readonly CustomersInformation_Readmodel _customers_information_Readmodel;

        public StarCups_DataServer(List<object> history)
        {
            _customers_information_Readmodel = new CustomersInformation_Readmodel(history);
        }

        public object Query(object query)
        {
            if (query is Number_of_customers) return Handle((Number_of_customers) query);
            if (query is Customer_Names) return Handle((Customer_Names) query);
            
            throw new ArgumentException($"Unknown query {query.GetType()}");
        }

        private string[] Handle(Customer_Names query) => _customers_information_Readmodel.Names();
        private int Handle(Number_of_customers query) => _customers_information_Readmodel.Count();
    }
}