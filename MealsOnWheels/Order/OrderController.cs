using MealsOnWheels.Customers;
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

    //ordern kan nu returnera null ifall ordersumman är för låg/sofia
    public Order? CreateOrder(
        Customer customer,
        Restaurant restaurant,
        List<OrderItems> orderItems)
    {
        if (customer == null || restaurant == null ||
           orderItems == null || orderItems.Count == 0)
        {
            throw new ArgumentException("Ogiltig beställning.");
        }

        // Beräknar och kontrollerar beställningens totalsumma
        decimal orderTotal = orderItems.Sum(
            item => item.MenuItem.Price * item.Quantity);

        if (!restaurant.MeetsMinimumOrder(orderTotal))
        {
            Console.WriteLine("Beställningen uppfyller inte restaurangens minimibeloppkrav.");
            return null;
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


    // simulera order när payment blivit godkänd
    public void SimulateOrder(Order order)
    {
        order.NotifyObservers();

        Thread.Sleep(2000);
        order.NextState();

        Thread.Sleep(3000);
        order.NextState();

        Thread.Sleep(2000);
        order.NextState();
    }


}
