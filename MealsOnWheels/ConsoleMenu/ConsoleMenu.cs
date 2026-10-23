using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
namespace MealsOnWheels;

public class ConsoleMenu
{
    RestaurantService _restaurantService;
    CheckoutMenu _checkoutMenu;

    private OrderController _orderController;

    public ConsoleMenu(RestaurantService restaurants, CheckoutMenu checkoutMenu)
    {
        _restaurantService = restaurants;
        _checkoutMenu = checkoutMenu;
        _orderController = new OrderController(new DeliveryService());
    }

    public void StartMenu()
    {
        while (true)
        {
            Console.WriteLine("Välkommen!");
            Console.WriteLine("Välj ett alternativ");
            Console.WriteLine("1. Visa restauranger");
            Console.WriteLine("2. Kolla status");
            Console.WriteLine("3. En annan sak");

            char choice = Console.ReadKey(true).KeyChar;

            switch (choice)
            {
                case '1':
                    {
                        RestaurantsMenu();
                        break;
                    }
                case '2':
                    {
                        SearchOrderById();
                        break;
                    }

                case '3':
                    { 
                        break;
                    }
            }
        }
    }

    public void RestaurantsMenu() 
    {
        while (true)
        {
            var restaurants = _restaurantService.GetRestaurants();
            Console.WriteLine("Välj en restaurang:");
            for (int i = 0; i < restaurants.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {restaurants[i].Name}");
            }
            char choice = Console.ReadKey(true).KeyChar;
            int index = choice - '1';

            if (index >= 0 && index < restaurants.Count)
            {
                bool completed = ShowMenu(restaurants[index]);
                if (completed)
                    break;
            }
            else
            {
                Console.WriteLine("Oglitigt val");
            }
        }
    }

    public bool ShowMenu(Restaurant restaurant)
    {
        List<OrderItems> Cartitems = new List<OrderItems>();
        while (true)
        {
            //Fixa så att användaren får välja hur många av varorna de vill ha, samt använda deras val i new OrderItems()
            Console.WriteLine("Välj en vara");
            for (int i = 0; i < restaurant.Menu.Count; i++)
            {
                Console.WriteLine($"{i + 1} {restaurant.Menu[i].Name}");
            }
            Console.WriteLine("0. Gå till checkout");

            char choice = Console.ReadKey(true).KeyChar;
            int index = choice - '1';


            if (index >= 0 && index < restaurant.Menu.Count)
            {
                var selectedItem = restaurant.Menu[index];
                int selectedAmount;
                Console.WriteLine("Hur många vill du ha?");
                if (int.TryParse(Console.ReadLine(), out selectedAmount) && selectedAmount > 0)
                {
                    OrderItems orderItems = new OrderItems(selectedItem, selectedAmount);
                    Cartitems.Add(orderItems);
                    Console.WriteLine($"{selectedAmount}st {selectedItem.Name}");
                }

                else
                {
                    Console.WriteLine("Ogiltigt antal");
                }
            }

            else
            {
                Console.WriteLine("Oglitigt val");
            }

            if (choice == '0')
            {
                bool completed = _checkoutMenu.Menu(restaurant, Cartitems);
                if (completed)
                    return true;
            }
        }
    }
        public void SearchOrderById()
         { 

        Console.Write("Ange order-ID du vill söka efter: ");
        if (int.TryParse(Console.ReadLine(), out int searchId))
        {
            var order = _orderController.GetOrderById(searchId);

            if (order != null)
            {
                Console.WriteLine($"Order hittad! Order-ID: {order.orderId}");

            }
            else
            {
                Console.WriteLine($"Ingen order hittades med ID {searchId}.");
            }
        
        }
    }
}
