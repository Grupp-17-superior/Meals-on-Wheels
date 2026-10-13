using System;
using System.Collections.Generic;
using System.Text;
namespace MealsOnWheels;

public class DeliveredState : IOrderState
{
    public void Next(Order order) => Console.WriteLine("Ordern är levererad och avslutad.");
    public void Cancel(Order order) => Console.WriteLine("En levererad order kan inte avbrytas.");

    public string GetStatusName() => "Levererad";
}