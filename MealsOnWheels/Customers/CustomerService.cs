using MealsOnWheels.Customers;
using System;
using System.Collections.Generic;
using System.Text;
namespace MealsOnWheels;

//// Skapade ifall vi vill ha flera kunder och hantera dom på ett ställe. Kan annars tas bort
//public class CustomerService
//{
//    private List<Customer> _customers;


//    public CustomerService()
//    {
//        _customers = new List<Customer>();
//    }

//    public Customer CreateCustomer()
//    {
//        Console.WriteLine("Ange kundens namn:");
//        string name = Console.ReadLine();
//        Console.WriteLine("Ange kundens leveransadress:");
//        string deliveryAddress = Console.ReadLine();
//        Console.WriteLine("Ange kundens telefonnummer:");
//        string phoneNumber = Console.ReadLine();
//        Console.WriteLine("Ange kundens e-postadress:");
//        string email = Console.ReadLine();
//        int customerId = _customers.Count + 1; // Skapar ett unikt kund-ID baserat på antalet kunder i listan
//        Customer newCustomer = new Customer(name, customerId, deliveryAddress, phoneNumber, email);
//        AddCustomer(newCustomer);
//        Console.WriteLine($"Kund {name} har skapats med ID {customerId}.");
//        return newCustomer;
//    }
//    public void AddCustomer(Customer customer)
//    {
//        if (customer == null)
//        {
//            throw new ArgumentException("Ogiltig kund.");
//        }
//        _customers.Add(customer);
//    }
//}
public class CustomerService : ICustomerService
{
    private static int nextCustomerId = 1; //skapar ett costumer id
    private readonly List<Customer> customers = new();

    public Customer CreateCustomer(int customerId, string name, string deliveryAddress, string phoneNumber, string email)
    {
        customerId = nextCustomerId++;
        Customer customer = new Customer(customerId, name, deliveryAddress, phoneNumber, email);

        customers.Add(customer);

        return customer;
    }
}