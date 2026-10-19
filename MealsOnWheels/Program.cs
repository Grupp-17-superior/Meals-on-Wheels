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
    }
}