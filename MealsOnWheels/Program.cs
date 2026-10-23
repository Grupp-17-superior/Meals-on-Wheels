,

﻿
using System;
using System.Collections.Generic;
namespace MealsOnWheels;

class Program
{
    static void Main(string[] args)
    {
        DeliveryService deliveryService = new DeliveryService();
        PaymentService paymentService = new PaymentService();
        RestaurantService restaurantService = new RestaurantService();
        CustomerService customerService = new CustomerService();

        OrderController orderController = new OrderController(deliveryService);
        CustomerController customerController = new CustomerController(customerService);

        restaurantService.CreateRestaurant();

        // Samma orderController skickas till både CheckoutMenu och ConsoleMenu!
        CheckoutMenu checkoutMenu = new CheckoutMenu(orderController, customerController, paymentService);
        ConsoleMenu consoleMenu = new ConsoleMenu(restaurantService, checkoutMenu, orderController);

        consoleMenu.StartMenu();
    }
}