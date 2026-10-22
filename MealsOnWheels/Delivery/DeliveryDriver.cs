using System;
using System.Collections.Generic;
namespace MealsOnWheels;

public class DeliveryDriver : IOrderObserver
{
	public int DriverId { get; set; }
	public string Name { get; set; }
	public string PhoneNumber { get; set; }
	public string VehicleType { get; set; } // T.ex. "Cykel", "Moped", "Bil"
	public bool IsAvailable { get; set; } = true;

	// Aktuell order som budet levererar just nu
	public Order? CurrentOrder { get; internal set; }

	public DeliveryDriver(int driverId, string name, string phoneNumber, string vehicleType)
	{
		DriverId = driverId;
		Name = name;
		PhoneNumber = phoneNumber;
		VehicleType = vehicleType;
	}





	public void CompleteDelivery()
	{
		if (CurrentOrder != null)
		{
			Console.WriteLine($"[Bud {Name}] Har slutfört leveransen av order #{CurrentOrder.orderId}.");
			CurrentOrder.RemoveObserver(this);
			CurrentOrder = null;
			IsAvailable = true;
		}
	}

	// Implementering av IOrderObserver
	public void Update(Order order)
	{
		Console.WriteLine($"[Bud {Name}] Notis: Order #{order.orderId} har ändrat status till: {order.GetState()}");

		// Exempel på hantering när ordern är klar för upphämtning eller avbruten
		if (order.GetState().Equals("ReadyForPickup", StringComparison.OrdinalIgnoreCase))
		{
			Console.WriteLine($"[Bud {Name}] Order #{order.orderId} är redo att hämtas på {order.restaurant.Name} ({order.restaurant.Address}).");
		}
		else if (order.GetState().Equals("Cancelled", StringComparison.OrdinalIgnoreCase))
		{
			Console.WriteLine($"[Bud {Name}] Order #{order.orderId} har avbrutits. Återgår till tillgänglig.");
			CurrentOrder = null;
			IsAvailable = true;
		}
	}
}