using System;
using System.Collections.Generic;
using System.Text;
namespace MealsOnWheels;

internal class NoDiscount : IDiscountStrategy
{
    public decimal Apply(decimal price) // detta är det helt vanliga priset
    {
        return price;
    }
}
