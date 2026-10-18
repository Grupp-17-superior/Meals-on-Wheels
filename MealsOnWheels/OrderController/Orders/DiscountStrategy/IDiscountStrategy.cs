using System;
using System.Collections.Generic;
using System.Text;
namespace MealsOnWheels;

internal interface IDiscountStrategy // detta är kontraktet som beskriver en rabbatt strategi
    {
    public decimal Apply(decimal price);
    }
