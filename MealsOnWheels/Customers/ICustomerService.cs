using System;
using System.Collections.Generic;
using System.Text;

namespace MealsOnWheels.Customers
{
    public interface ICustomerService
    {
        Customer CreateCustomer(int customerId, string name, string deliveryAddress, string phoneNumber, string email);
    }
}
