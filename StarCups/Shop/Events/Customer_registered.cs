namespace StarCups.Shop.Events
{
    public struct Customer_registered
    {
        public CustomerReference Customer { get; }
        public string Name { get; }
        public string Familyname { get; }

        public Customer_registered(CustomerReference customer, string name, string familyname)
        {
            Customer = customer;
            Name = name;
            Familyname = familyname;
        }
    }
}