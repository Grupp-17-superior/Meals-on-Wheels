using System;
using System.Collections.Generic;
using System.Text;
namespace MealsOnWheels;

public class PreparingState : IOrderState
{
    public void Next(Order order) => order.SetState(new OutForDeliveryState());
    public void Cancel(Order order) => order.SetState(new CancelledState()); //hur får man avbryta?

    public string GetStatusName() => "Förbereder";
}
