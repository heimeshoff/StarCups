using NUnit.Framework;
using StarCups.Shop;

namespace StarCups_Specs.Shop
{
    [TestFixture]
    public partial class CustomerRegistration_Specs : TestBase
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

        [Test]
        public void A_customer_can_register_only_once()
        {
            var customer = NewCustomer();

            Given(
                Customer_registered(
                    customer, "Marco", "Heimeshoff"));
            When(
                Register_customer(
                    customer, "Marco", "Heimeshoff"));
            Then_expect(
                Customer_registration_denied(customer, Reason.Already_registered));
        }
    }
}