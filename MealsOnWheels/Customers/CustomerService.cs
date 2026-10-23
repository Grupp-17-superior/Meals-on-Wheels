using System;
using System.Collections.Generic;
using System.Text;
namespace MealsOnWheels;

public class CustomerService : ICustomerService
{
    private static int nextCustomerId = 1; //skapar ett costumer id
    private readonly List<Customer> customers = new();

    public Customer CreateCustomer(string name, string deliveryAddress, string phoneNumber, string email)// grasp creator, ansvarar för att skapa kunden
    {
        int customerId = nextCustomerId++;
        Customer customer = new Customer(customerId, name, deliveryAddress, phoneNumber, email);

        customers.Add(customer);

        return customer;
    }
}