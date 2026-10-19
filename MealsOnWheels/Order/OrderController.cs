using System;
using System.Collections.Generic;
using System.Text;
namespace MealsOnWheels;


public class OrderController
{
    private DeliveryService _deliveryService;
    private List<Order> _orders = new List<Order>();

    public OrderController(DeliveryService deliveryService)
    {
        _deliveryService = deliveryService;
    }

    public Order CreateOrder(
        Customer customer,
        Restaurant restaurant,
        List<OrderItems> orderItems)
    {
        if (customer == null || restaurant == null ||
           orderItems == null || orderItems.Count == 0)
        {
            throw new ArgumentException("Ogiltig beställning.");
        }

        Order order = new Order (customer, restaurant, orderItems);
        _orders.Add(order);
        return order;
    }

    //public bool ProcessPayment(Order order, decimal amount)
    //{
    //    if (order == null || amount <= 0)
    //    {
    //        return false;
    //    }

    //    // Hantera betalning genom att använda Order.CalculateTotalPrice() och sedan använda Strategies för att applicera rabatter.


    //}
}
