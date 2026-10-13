using System;
using System.Collections.Generic;
using System.Text;

namespace MealsOnWheels.OrderController.Orders
{
    public class Order //det som behövs för state i order /sofia
    {
        private IOrderState currentState = new ReceivedState(); //referens till state

        public void SetState(IOrderState newState) //ändra state
        {
            currentState = newState;
        }

        public void Next() //flytta mellan states
        {
            currentState.Next(this);
        }

        public void Cancel()
        {
            currentState.Cancel(this);
        }

        public string GetStatus()
        {
            return currentState.GetStatusName();
        }

    }
}
