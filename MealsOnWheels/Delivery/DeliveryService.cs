using System;
using System.Collections.Generic;
using System.Text;
namespace MealsOnWheels;

public class DeliveryService    
{
        
    private List<DeliveryDriver> _driverList;


    public DeliveryService()
    {
        _driverList = new List<DeliveryDriver>();
    }


    public void AddDriver(DeliveryDriver driver)
    {
        if(driver == null)
        {
            throw new ArgumentException("Ogiltigt bud.");
        }
        _driverList.Add(driver);

    }

    //behöver implementeras, koppla ihop orderID och driverID
    public DeliveryDriver? AssignDriver(Order order)
    {
        if (order == null)
        {
            throw new ArgumentNullException(nameof(order));
        }

        // Tilldela inte en andra order till samma bud
        // eller skriv över ett befintligt bud på ordern.
        if (order.deliveryDriver != null)
        {
            return order.deliveryDriver;
        }

        DeliveryDriver? driver =
            _driverList.Find(d => d.IsAvailable);

        if (driver == null)
        {
            Console.WriteLine("Det finns inga lediga bud.");
            return null;
        }

        // Koppla ihop ordern och budet
        order.DriverID = driver.DriverId;
        order.deliveryDriver = driver;

        driver.CurrentOrder = order;
        driver.IsAvailable = false;

        // Budet får statusuppdateringar från ordern
        order.AddObserver(driver);

        Console.WriteLine(
            $"Bud {driver.Name} (ID {driver.DriverId}) " +
            $"har tilldelats order #{order.orderId}.");

        return driver;
    }
}