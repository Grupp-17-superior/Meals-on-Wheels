
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

public void ProcessPayment(Order order, IDiscountStrategy? strategy)
    {
        if (order == null)
        {
            throw new ArgumentException("Ogiltig beställning.");
        }
        decimal finalPrice = strategy.Apply(order.CalculateTotalPrice());

        Console.WriteLine($"Slutpris: {finalPrice}kr");
        string test = Console.ReadLine();
    }


    // simulera order när payment blivit godkänd
    public void SimulateOrder(Order order)
    {
        order.NotifyObservers();

        Thread.Sleep(2000);
        order.NextState();

        Thread.Sleep(3000); //levererar
        order.NextState();
        DeliveryDriver? driver = _deliveryService.AssignDriver(order);
        if (driver == null)
        {
            Console.WriteLine("Det finns inget ledigt bud nu. Vänligen vänta tills en bud blir ledig.");
            return;
        }
        Thread.Sleep(2000);
        order.NextState();//levererad
        driver.CompleteDelivery(_deliveryService); //budet blir ledig igen och sätts sist i kön.
    }
    //tar OrderID för kund sökning/staturs uppdatering
    public Order? GetOrderById(int orderId)
    {
        return _orders.FirstOrDefault(o => o.orderId == orderId);

    
    }
}
