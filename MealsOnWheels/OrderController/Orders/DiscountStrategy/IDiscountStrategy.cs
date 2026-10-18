using System;
using System.Collections.Generic;
using System.Text;
namespace MealsOnWheels;
public interface IDiscountStrategy
    {
    public decimal Apply(decimal price);
    }
