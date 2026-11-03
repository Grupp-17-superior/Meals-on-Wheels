using System;
using System.Collections.Generic;
using System.Text;
namespace MealsOnWheels;

public class Order //det som behövs för state i order /sofia
{
    public int orderId { get; set; }
    private static int nextId = 1;
    public int? DriverID { get; set; }
    public object Status { get; internal set; }
    public object Restaurant { get; internal set; }

    public Restaurant restaurant;
    public Customer customer;

    public DeliveryDriver? deliveryDriver;

    private List<OrderItems> orderItems = new List<OrderItems>();
    private List<IOrderObserver> observers = new List<IOrderObserver>();

    private IDiscountStrategy? discountStrategy;
    private IOrderState currentState = new ReceivedState(); //referens till state

    public Order(Customer customer, Restaurant restaurant, List<OrderItems> orderItems)
    {
        this.customer = customer;
        this.restaurant = restaurant;
        this.orderItems = orderItems;
        orderId = nextId++;

        CustomerNotificationObserver notification =
        new CustomerNotificationObserver(customer);

        AddObserver(notification);
        AddObserver(restaurant);
    }

    public async Task ProcessOrderAsync()
    {
        while (currentState is not DeliveredState &&
               currentState is not CancelledState)
        {
            await Task.Delay(TimeSpan.FromMinutes(1));

            if (currentState is CancelledState)
                break;

            NextState();
        }
    }

    public void GetItems()
    {
        foreach (var item in orderItems)
        {
            Console.WriteLine($"Item: {item.MenuItem.Name}, {item.Quantity}");
        }
    }
    public void SetState(IOrderState newState) //ändra state
    {
        currentState = newState;
        NotifyObservers(); // skicka notifiering till observatörer varje statebyte
    }

    public void NextState() //flytta mellan states
    {
        currentState.Next(this);
    }

    public void CancelState() //Cancel order?
    {
        currentState.Cancel(this);
    }

    public string GetState()
    {
        return currentState.GetStatusName();
    }

    public void AddObserver(IOrderObserver observer)
    {
        observers.Add(observer);
    }
    
    public void RemoveObserver(IOrderObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.Update(this);
        }
    }

    public decimal CalculateTotalPrice()
    { 
        decimal total = 0;

        foreach (var item in orderItems)
        {
            total += item.MenuItem.Price * item.Quantity;
        }

        return total;
    }
    
    public void SetDiscountStrategy(IDiscountStrategy strategy)//sparar den rabbatstrategi kunden har valt
    {
        discountStrategy = strategy;
    }

    public decimal CalculateFinalPrice() // beräknar ordens slutpris efter rabbatstrategi har applicerats
    {
        decimal total = CalculateTotalPrice();

        if (discountStrategy == null)
        {
            return total;
        }

        return discountStrategy.Apply(total);
    }

}

