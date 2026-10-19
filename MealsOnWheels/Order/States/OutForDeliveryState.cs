using System;
using System.Collections.Generic;
using System.Text;
namespace MealsOnWheels;

public class OutForDeliveryState : IOrderState
{
    public void Next(Order order) => order.SetState(new DeliveredState());

    public void Cancel(Order order) => order.SetState(new CancelledState()); //hur får man avbryta?

    public string GetStatusName() => "Levererar";
}