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


    }

    //behöver implementeras, koppla ihop orderID och driverID
    //public DeliveryDriver AssignDriver(Order order)
    //{

    //}
}