using System;
using System.Collections.Generic;
using System.Text;

namespace MealsOnWheels;

public class CancelledState : IOrderState
{
    public void Next(Order order) => Console.WriteLine("Ordern är avbruten.");

    public void Cancel(Order order) => Console.WriteLine("Ordern är redan avbruten.");

    public string GetStatusName() => "Avbruten";
}
