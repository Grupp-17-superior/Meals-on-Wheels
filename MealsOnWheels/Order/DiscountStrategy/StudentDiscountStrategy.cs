using System;
using System.Collections.Generic;
using System.Text;
namespace MealsOnWheels;

public class StudentDiscountStrategy : IDiscountStrategy
{
    public decimal Apply(decimal price)
    {
        return price * 0.9m;
    }
}