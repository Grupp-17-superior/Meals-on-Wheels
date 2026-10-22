using System;
using System.Collections.Generic;
using System.Text;

namespace MealsOnWheels.Customers
{
    public class CustomerController
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        public Customer CreateCustomer(string name, string address, string phone, string email)
        {
            return customerService.CreateCustomer(name, address, phone, email);
        }
        public void RegisterCustomer()
        {
            Console.WriteLine("Ange ditt namn:");
            string name = Console.ReadLine() ?? "";

            Console.WriteLine("Ange din leveransadress:");
            string address = Console.ReadLine() ?? "";

            Console.WriteLine("Ange ditt telefonnummer:");
            string phone = Console.ReadLine() ?? "";

            Console.WriteLine("Ange din e-postadress:");
            string email = Console.ReadLine() ?? "";

            Customer customer = customerService.CreateCustomer(name, address, phone, email);

            Console.WriteLine(
                $"Kund skapad! Ditt kund-ID är {customer.GetCustomerId()}");
        }
    }
}
