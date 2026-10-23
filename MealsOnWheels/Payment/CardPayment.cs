using System;
using System.Collections.Generic;
using System.Text;
namespace MealsOnWheels;

public class CardPayment : IPaymentStrategy
{
    public bool Pay(decimal amount)
    {
        Console.WriteLine(
            $"Kortbetalning på {amount} kr genomförd!");

        return true;
    }
}
