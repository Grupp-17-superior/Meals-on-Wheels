using System;
using System.Collections.Generic;
using System.Text;
namespace MealsOnWheels;

public class FixedDiscountStrategy(decimal fixedAmount) : IDiscountStrategy
{
    public decimal Apply(decimal price) // denna tar bort en summa från priset, jag tänkte typ delivery fee eller något
    {
        return price - fixedAmount;
    }
}
