using System;
using System.Collections.Generic;
using System.Text;
namespace MealsOnWheels;

public class NoDiscount : IDiscountStrategy
{
    public decimal Apply(decimal price)
    {
        return price;
    }
}

