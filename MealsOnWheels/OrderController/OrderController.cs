using System;
using System.Collections.Generic;
using System.Text;
namespace MealsOnWheels;


public class OrderController
{
    private Leveranstjanst _leveranstjanst;

    public OrderController(Leveranstjanst leveranstjanst)
    {
        _leveranstjanst = leveranstjanst;
    }

    public Order CreateOrder(
        Customer kund,
        Resturant rest,
        List<OrderItem> items)
    {
        if (kund == null || rest == null ||
           items == null || items.Count == 0)
        {
            throw new ArgumentException("Ogiltig beställning.");
        }
        // Skapa order


    }

    public bool ProcessPayment(Order order, decimal amount)
    {
        if (order == null || amount <= 0)
        {
            return false;
        }
        // Hantera betalning


    }
}
