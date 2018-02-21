using FluentAssertions;
using NUnit.Framework;
using StarCups.Shop.Information;

namespace StarCups_Specs.Shop
{
    [TestFixture]
    public partial class CustomerRegistration_Specs : TestBase
    {
        //Behaviour Specifications

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

        // Projection Specifications

        [Test]
        public void RegisteredCustomers_Projection_Count()
        {
            Given(
                Customer_registered(NewCustomer(), "Marco", "Heimeshoff"),
                Customer_registered(NewCustomer(), "Aaron", "Avenger"),
                Customer_registered(NewCustomer(), "Berta", "Blumentopf"),
                Customer_registered(NewCustomer(), "Caesar", "Crimson"),
                Customer_registered(NewCustomer(), "Heino", "Höfig"),
                Customer_registered(NewCustomer(), "Bobby", "DropTables"));

            var response =
                Query(
                    NumberOfCustomers());

            response.Should().Be(6);
        }

        [Test]
        public void RegisteredCustomers_Names()
        {
            Given(
                Customer_registered(NewCustomer(), "Marco", "Heimeshoff"),
                Customer_registered(NewCustomer(), "Aaron", "Avenger"),
                Customer_registered(NewCustomer(), "Berta", "Blumentopf"),
                Customer_registered(NewCustomer(), "Caesar", "Crimson"),
                Customer_registered(NewCustomer(), "Heino", "Höfig"),
                Customer_registered(NewCustomer(), "Bobby", "DropTables"));

            var response =
                Query(
                    Customer_Names());

            (response as string[]).Should().Contain("Marco");
        }

        // Full API Specifications

        [Test]
        public void Custer_Registration_Full_API_Test()
        {
            var customer = NewCustomer();

            Given(
                Customer_registered(NewCustomer(), "Marco", "Heimeshoff"),
                Customer_registered(NewCustomer(), "Aaron", "Avenger"));

            var firstResponse = 
                Query(
                    Customer_Names());
            When(
                Register_customer(
                    customer, "Dave", "Snowden"));
            var secondResponse =
                Query(
                    Customer_Names());

            (firstResponse as string[]).Should().NotContain("Dave");
            (secondResponse as string[]).Should().Contain("Dave");
        }
    }
}