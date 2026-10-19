using System;
using System.Collections.Generic;

namespace MealsOnWheels;

public class Customer : IOrderObserver
{
	public int CustomerId { get; set; }
	public string Name { get; set; }
	public string DeliveryAddress { get; set; }
	public string PhoneNumber { get; set; }
	public string Email { get; set; }

	// Historik över alla ordrar som kunden har lagt
	public List<Order> OrderHistory { get; private set; } = new List<Order>();

	public Customer(int customerId, string name, string deliveryAddress, string phoneNumber, string email)
	{
		CustomerId = customerId;
		Name = name;
		DeliveryAddress = deliveryAddress;
		PhoneNumber = phoneNumber;
		Email = email;
	}

	// Lägger till en ny order i kundens historik
	public void PlaceOrder(Order order)
	{
		OrderHistory.Add(order);
		Console.WriteLine($"[Kund {Name}] Order #{order.orderId} har lagts!");
	}

	// Implementering av IOrderObserver
	public void Update(Order order)
	{
		Console.WriteLine($"[Kund {Name}] Notifikation: Din order #{order.orderId} hos {order.restaurant.Name} har ändrat status till: '{order.GetState()}'");

		// Exempel på anpassade meddelanden beroende på status
		switch (order.GetState().ToLower())
		{
			case "delivered":
				Console.WriteLine($"[Kund {Name}] Smaklig måltid! Din mat har levererats till {DeliveryAddress}.");
				break;
			case "cancelled":
				Console.WriteLine($"[Kund {Name}] Din order #{order.orderId} har blivit avbruten.");
				break;
		}
	}
}