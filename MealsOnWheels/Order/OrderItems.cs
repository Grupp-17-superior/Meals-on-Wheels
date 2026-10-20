using System;
using System.Collections.Generic;
using System.Text;
namespace MealsOnWheels;

public class OrderItems
{
    public MenuItem MenuItem { get; set; }
    public int Quantity { get; set; }

    public OrderItems(MenuItem menuItem, int quantity)
    {
        MenuItem = menuItem;
        Quantity = quantity;
    }
}
