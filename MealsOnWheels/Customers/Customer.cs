using System;
using System.Collections.Generic;
namespace MealsOnWheels;

public class Customer : IOrderObserver
{
    private static int nextCustomerId = 1; //skapar ett costumer id
    public int _customerId { get; } // tog bort set så att customer id inte kan ändras utifrån så vi slipper problem med att koppla order till customer.
	public string _name { get; set; }
	public string _deliveryAddress { get; set; }
	public string _phoneNumber { get; set; }
	public string _email { get; set; }

	public Customer(string name, int customerId, string deliveryAddress, string phoneNumber, string email)
	{
        _name = name;
        _customerId = customerId;
        _deliveryAddress = deliveryAddress;
		_phoneNumber = phoneNumber;
		_email = email;
	}

	// Implementering av IOrderObserver
	public void Update(Order order)
	{
		string status = order.GetState();

		// anpassade meddelanden beroende på status
		switch (status)
		{
			case "Mottagen":
                Console.WriteLine($"[Kund {_name} Din order #{order.orderId} " +
            $"hos {order.restaurant.Name} har tagits emot");
				break;

            case "Förbereder":
				Console.WriteLine(
					$"[Kund {_name}], din mat tillagas av {order.restaurant.Name}");
				break;
			case "Levererar":
				Console.WriteLine("Budet är på väg med din mat!");
				break;

            case "Levererad":
				Console.WriteLine($"[Kund {_name}] Smaklig måltid!" +
					$" Din mat har levererats till.");
				break;
			case "Avbruten":
				Console.WriteLine($"[Kund {_name}] Din order #{order.orderId} har blivit avbruten.");
				break;
		}
	}
}