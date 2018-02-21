namespace StarCups.Shop.Events
{
    public struct Customer_registration_denied
    {
        public CustomerReference Customer { get; }
        public Reason Reason { get; }

        public Customer_registration_denied(CustomerReference customer, Reason reason)
        {
            Customer = customer;
            Reason = reason;
        }
    }
}