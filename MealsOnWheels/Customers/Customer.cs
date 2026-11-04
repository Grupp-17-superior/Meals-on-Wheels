using System;
using System.Collections.Generic;
namespace MealsOnWheels;

public class Customer 
{
    
    private int _customerId { get; } // tog bort set så att customer id inte kan ändras utifrån så vi slipper problem med att koppla order till customer.
    public string Name { get; private set; }
    private string DeliveryAddress { get; set; }
    private string PhoneNumber { get; set; }
    private string Email { get; set; }
    

    public Customer(int customerId, string name, string deliveryAddress, string phoneNumber, string email)
    {
        _customerId = customerId;
        Name = name;
        DeliveryAddress = deliveryAddress;
        PhoneNumber = phoneNumber;
        Email = email;
    }

    public string GetName() => Name;// detta gör så att jag kan koppla kundens namn fast att den är privat i klassen. (getter(fat arrow function)))
    public int GetCustomerId() => _customerId;
}