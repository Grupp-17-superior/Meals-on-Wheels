using System;
using System.Collections.Generic;
namespace MealsOnWheels;

public class Customer 
{
    
    private int _customerId { get; } // tog bort set så att customer id inte kan ändras utifrån så vi slipper problem med att koppla order till customer.
    private string _name { get; set; }
    private string _deliveryAddress { get; set; }
    private string _phoneNumber { get; set; }
    private string _email { get; set; }

    public Customer(int customerId, string name, string deliveryAddress, string phoneNumber, string email)
    {
        _customerId = customerId;
        _name = name;
        _deliveryAddress = deliveryAddress;
        _phoneNumber = phoneNumber;
        _email = email;
    }

    public string GetName() => _name;// detta gör så att jag kan koppla kundens namn fast att den är privat i klassen. (getter(fat arrow function)))
    public int GetCustomerId() => _customerId;
}