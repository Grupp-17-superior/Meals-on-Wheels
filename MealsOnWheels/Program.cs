using MealsOnWheels.Customers;
using MealsOnWheels.Payment;
using System;
using System.Collections.Generic;

namespace MealsOnWheels;

class Program
{
	static void Main(string[] args)
	{
		DeliveryService deliveryService = new DeliveryService();
        OrderController orderController = new OrderController(deliveryService);
		RestaurantService restaurantService = new RestaurantService();
        CustomerService customerService = new CustomerService();
        CustomerController customerController = new CustomerController(customerService);
        PaymentService paymentService = new PaymentService();
        restaurantService.CreateRestaurant();
        CheckoutMenu checkoutMenu = new CheckoutMenu(orderController, customerController, paymentService);
        ConsoleMenu consoleMenu = new ConsoleMenu(restaurantService, checkoutMenu);

        consoleMenu.StartMenu();

    }
}