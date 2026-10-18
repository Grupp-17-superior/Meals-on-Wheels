using System;
using System.Collections.Generic;
using System.Text;
namespace MealsOnWheels;

   public class PercentageDiscount(decimal percentage) : IDiscountStrategy
    {
    public decimal Apply(decimal price)
    {
        return price * (1 - percentage / 100m); // det här kommer returnera ett värde där procentsatsen tas bort, valde 100m då vi inte kan ha mer än 100% rabbatt.
    }
      
   
}