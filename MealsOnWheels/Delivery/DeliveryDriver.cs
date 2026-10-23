using System;
using System.Collections.Generic;
namespace MealsOnWheels;

public class DeliveryDriver : IOrderObserver
{
	public int DriverId { get; set; }
	public string Name { get; set; }
	public string PhoneNumber { get; set; }
	public string VehicleType { get; set; } // T.ex. "Cykel", "Moped", "Bil"
	public string status { get; private set; } 
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





	public void CompleteDelivery(DeliveryService deliveryService)
	{
		if (CurrentOrder != null)
		{
			Console.WriteLine($"[Bud {Name}] Har slutfört leveransen av order #{CurrentOrder.orderId}.");
			CurrentOrder.RemoveObserver(this);
			CurrentOrder = null;
			IsAvailable = true;

			deliveryService.ReturnDriver(this);
		}
	}

	// Implementering av IOrderObserver
	public void Update(Order order)
	{
		status = order.GetState();
    }
}