using System;
using System.Collections.Generic;

namespace MealsOnWheels;

class Program
{
	static void Main(string[] args)
	{
		Console.WriteLine("=== Meals On Wheels - Systemstart ===\n");

		// 1. Skapa en restaurang och lägg till menyrätter
		Restaurant restaurant = new Restaurant(1, "Pizzeria Bella", "Storgatan 10", "070-1234567");

		MenuItem pizza = new MenuItem(101, "Vesuvio", "Skinka och ost", 110m);
		MenuItem drick = new MenuItem(102, "Coca-Cola", "33cl", 25m);

		restaurant.AddMenuItem(pizza);
		restaurant.AddMenuItem(drick);

		// 2. Skapa en kund
		Customer customer = new Customer(1, "Anna Andersson", "Lillgatan 5", "073-9876543", "anna@example.com");

		// 3. Skapa ett bud
		DeliveryDriver driver = new DeliveryDriver(1, "Erik Ek", "072-0001122", "Cykel");

		// 4. Bygg ihop varukorgen/order-items
		List<OrderItem> items = new List<OrderItem>
		{
			new OrderItem(pizza, 2), // 2 st Vesuvio
            new OrderItem(drick, 1)  // 1 st Coca-Cola
        };

		Console.WriteLine("--- Skapar ny order ---");
		// 5. Skapa ordern via restaurangen
		Order order = restaurant.CreateOrder(customer, items, driver);
		order.orderId = 1001;
		customer.PlaceOrder(order);

		Console.WriteLine($"\nUrsprunglig status på order: {order.GetState()}");

		// 6. Simulera flödet genom olika states
		Console.WriteLine("\n--- Ändrar orderstatus (NextState) ---");
		order.NextState(); // Flyttar från t.ex. ReceivedState -> PreparingState

		Console.WriteLine("\n--- Tilldelar bud och flyttar vidare ---");
		driver.AssignOrder(order);
		order.NextState(); // Flyttar från PreparingState -> ReadyForPickupState / InTransitState

		Console.WriteLine("\n--- Slutför leveransen ---");
		order.NextState(); // Flyttar till DeliveredState
		driver.CompleteDelivery();

		Console.WriteLine("\n=== Demonstration klar ===");
	}
}