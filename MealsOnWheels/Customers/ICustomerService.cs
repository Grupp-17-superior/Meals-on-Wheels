using System;
using System.Collections.Generic;
using System.Text;

namespace MealsOnWheels;

public interface ICustomerService
{
    Customer CreateCustomer(string name, string deliveryAddress, string phoneNumber, string email);
}
