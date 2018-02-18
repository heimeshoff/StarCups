using NUnit.Framework;

namespace StarCups_Specs.Shop
{
    [TestFixture]
    public partial class Customer_Specs : TestBase
    {
        [Test]
        public void A_customer_can_register()
        {
            var customer = NewCustomer();

            Given(
                Nothing_happened_so_far());
            When(
                Register_customer(
                    customer, "Marco", "Heimeshoff"));
            Then_expect(
                Customer_registered(customer, "Marco", "Heimeshoff"));
        }
    }
}