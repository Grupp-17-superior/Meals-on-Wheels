using System;
using System.Collections.Generic;
using System.Text;
namespace MealsOnWheels;

public class MenuItem
{
    public string Name { get; set; }
    public decimal Price { get; set; }

    public MenuItem(string name, decimal price)
    {
        Name = name;
        Price = price;
    }
}
