namespace StarCups.Shop.Commands
{
    public struct Register_customer
    {
        public CustomerReference Customer { get; }
        public string Name { get; }
        public string Familyname { get; }

        public Register_customer(CustomerReference customer, string name, string familyname)
        {
            Customer = customer;
            Name = name;
            Familyname = familyname;
        }
    }
}