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

    private List<OrderItem> orderItems = new List<OrderItem>();
    private List<IOrderObserver> observers = new List<IOrderObserver>();

    private IDiscountStrategy? discountStrategy;
    private IOrderState currentState = new ReceivedState(); //referens till state
    

    public Order(Restaurant restaurant, Customer customer, List<OrderItem> orderItems, DeliveryDriver? deliveryDriver = null)
    {
        this.restaurant = restaurant;
        this.customer = customer;
        this.deliveryDriver = deliveryDriver;
        this.orderItems = orderItems;
        orderId = nextId++;

        AddObserver(customer);
        AddObserver(restaurant);

        if (deliveryDriver != null)
            AddObserver(deliveryDriver);
    }

    public void SetState(IOrderState newState) //ändra state
    {
        currentState = newState;
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

    public void CalculateTotalPrice()
    {
    }
}

