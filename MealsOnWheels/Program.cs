using MealsOnWheels.Customers;
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
        restaurantService.CreateRestaurant();
        CheckoutMenu checkoutMenu = new CheckoutMenu(orderController, customerController);
        ConsoleMenu consoleMenu = new ConsoleMenu(restaurantService, checkoutMenu);

        consoleMenu.StartMenu();

    }
}