using MealsOnWheels.OrderController.Orders.States;
using System;
using System.Collections.Generic;
using System.Text;
namespace MealsOnWheels;

public class ReceivedState : IOrderState
{
    public void Next(Order order) => order.SetState(new PreparingState());
    public void Cancel(Order order) => order.SetState(new CancelledState());

    public string GetStatusName() => "Mottagen";
}   
