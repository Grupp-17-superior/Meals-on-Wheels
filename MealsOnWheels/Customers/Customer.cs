using System;
using System.Collections.Generic;
namespace MealsOnWheels;

public class Customer : IOrderObserver
{
    private static int nextCustomerId = 1; //skapar ett costumer id
    public int CustomerId { get; } // tog bort set så att customer id inte kan ändras utifrån så vi slipper problem med att koppla order till customer.
	public string Name { get; set; }
	public string DeliveryAddress { get; set; }
	public string PhoneNumber { get; set; }
	public string Email { get; set; }

	public Customer( string name, string deliveryAddress, string phoneNumber, string email)
	{
        CustomerId = nextCustomerId++;
        Name = name;
		DeliveryAddress = deliveryAddress;
		PhoneNumber = phoneNumber;
		Email = email;
	}

	// Implementering av IOrderObserver
	public void Update(Order order)
	{
		string status = order.GetState();

		// anpassade meddelanden beroende på status
		switch (status)
		{
			case "Mottagen":
                Console.WriteLine($"[Kund {Name} Din order #{order.orderId} " +
            $"hos {order.restaurant.Name} har tagits emot");
				break;

            case "Förbereder":
				Console.WriteLine(
					$"[Kund {Name}], din mat tillagas av {order.restaurant.Name}");
				break;
			case "Levererar":
				Console.WriteLine("Budet är på väg med din mat!");
				break;

            case "Levererad":
				Console.WriteLine($"[Kund {Name}] Smaklig måltid!" +
					$" Din mat har levererats till.");
				break;
			case "Avbruten":
				Console.WriteLine($"[Kund {Name}] Din order #{order.orderId} har blivit avbruten.");
				break;
		}
	}
}