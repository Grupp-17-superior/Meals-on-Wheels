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

        OrderService orderService = new OrderService(deliveryService);
        CustomerController customerController = new CustomerController(customerService);

        DeliveryDriverTestData.AddTestDrivers(deliveryService);
        restaurantService.CreateRestaurant();

        // Samma orderService skickas till både CheckoutMenu och ConsoleMenu!
        CheckoutMenu checkoutMenu = new CheckoutMenu(orderService, customerController, paymentService, deliveryService);
        ConsoleMenu consoleMenu = new ConsoleMenu(restaurantService, checkoutMenu, orderService);

        consoleMenu.StartMenu();
    }
}