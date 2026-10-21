using System;
using System.Collections.Generic;
using System.Text;
namespace MealsOnWheels;

public class CancelledState : IOrderState
{
    public void Next(Order order)
    {
        // Inget händer, allt är avbrutet i simuleringen
    }

    public void Cancel(Order order)
    {
        // Inget händer, allt är avbrutet i simuleringen
    }


    public string GetStatusName() => "Avbruten";
}
