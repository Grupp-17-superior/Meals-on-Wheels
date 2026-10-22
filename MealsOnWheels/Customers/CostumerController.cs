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

        public Customer CreateCustomer(int customerId, string name, string address, string phone, string email)
        {
            return customerService.CreateCustomer(customerId, name, address, phone, email);
        }
    }
}
