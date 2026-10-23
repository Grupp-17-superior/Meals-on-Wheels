using System;
using System.Collections.Generic;
using System.Text;

namespace MealsOnWheels;

public class SwoshPayment : IPaymentStrategy
{
    public bool Pay(decimal amount)
    {
        Console.WriteLine(
            $"Swosh-betalning på {amount} kr genomförd!");

        return true;
    }
}
