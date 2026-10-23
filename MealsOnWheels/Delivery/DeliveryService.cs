using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
namespace MealsOnWheels;

public class DeliveryService    
{
        
    private Queue<DeliveryDriver> availableDrivers = new Queue<DeliveryDriver>(); // en kö med lediga bud

    public void AddAvailableDriver(DeliveryDriver driver) // lägger till ett nytt bud sist i kön
    {
        if (driver == null)
        {
            throw new ArgumentNullException(nameof(driver));
        }
        availableDrivers.Enqueue(driver);
    }

    public DeliveryDriver? AssignDriver(Order order) // tilldelar nästa lediga bud och tar bort det från kön
    {
        if (order == null)
        {
            throw new ArgumentNullException(nameof(order));
        }
        if (order.deliveryDriver != null)
        {
            return order.deliveryDriver;
        }

        if (availableDrivers.Count == 0)
        {
            Console.WriteLine("Det finns inga lediga bud.");
            return null;
        }

        DeliveryDriver driver = availableDrivers.Dequeue(); // hämtar första budet från kön

        order.DriverID = driver.DriverId;
        order.deliveryDriver = driver;
        
        driver.CurrentOrder = order;
        driver.IsAvailable = false;

        order.AddObserver(driver);

        Console.WriteLine(
            $"Bud {driver.Name} (ID {driver.DriverId}) " +
            $"har tilldelats order #{order.orderId}.");

        return driver;
    }

    public void ReturnDriver(DeliveryDriver driver)
    {
        if (driver.IsAvailable && driver.CurrentOrder == null && !availableDrivers.Contains(driver))
        {
            availableDrivers.Enqueue(driver); // lägger tillbaka budet sist i kön efter leverans
        }
    }


}