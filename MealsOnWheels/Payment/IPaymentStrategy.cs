using System;
using System.Collections.Generic;
using System.Text;
namespace MealsOnWheels;

public interface IPaymentStrategy
{
    bool Pay(decimal amount);
}
