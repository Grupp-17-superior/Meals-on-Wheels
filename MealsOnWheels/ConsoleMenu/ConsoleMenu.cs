using System;
using System.Collections.Generic;
using System.Text;
namespace MealsOnWheels;

public class ConsoleMenu
{
    RestaurantService _restaurantService;
    OrderController _orderController;

    CustomerService _customerService;

    public ConsoleMenu(RestaurantService restaurants, OrderController orderController, CustomerService customerService)
    {
        _restaurantService = restaurants;
        _orderController = orderController;
        _customerService = customerService;
    }

    public void StartMenu()
    {
        while (true)
        {
            Console.WriteLine("Välkommen!");
            Console.WriteLine("Välj ett alternativ");
            Console.WriteLine("1. Visa restauranger");
            Console.WriteLine("2. En till sak");
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
                ShowMenu(restaurants[index]);
                break;
            }
            else
            {
                Console.WriteLine("Oglitigt val");
            }
        }
    }

    public void ShowMenu(Restaurant restaurant)
    {
        List<OrderItems> items = new List<OrderItems>();
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
                    items.Add(orderItems);
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
                Customer customer = _customerService.CreateCustomer();
                _orderController.CreateOrder(restaurant, customer, items);
                _orderController.ProcessPayment();

                break;
            }
        }
    }
}
