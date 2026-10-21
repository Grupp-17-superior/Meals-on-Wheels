using System;
using System.Collections.Generic;
using System.Text;
namespace MealsOnWheels;

public class Order //det som behövs för state i order /sofia
{
    public int orderId;
    private static int nextId = 0;

    public Restaurant restaurant;
    public Customer customer;
    public DeliveryDriver? deliveryDriver;

    private List<OrderItems> orderItems = new List<OrderItems>();
    private List<IOrderObserver> observers = new List<IOrderObserver>();

    private IDiscountStrategy? discountStrategy;
    private IOrderState currentState = new ReceivedState(); //referens till state

    public Order(Customer customer, Restaurant restaurant, List<OrderItems> orderItems)
    {
        this.restaurant = restaurant;
        this.customer = customer;
        this.orderItems = orderItems;
        orderId = nextId++;

        AddObserver(customer);
        AddObserver(restaurant);
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
}

