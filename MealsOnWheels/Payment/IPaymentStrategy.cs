using System;
using System.Collections.Generic;
using System.Text;

namespace MealsOnWheels.Payment
{
    public interface IPaymentStrategy
    {
        bool Pay(decimal amount);
    }
}
