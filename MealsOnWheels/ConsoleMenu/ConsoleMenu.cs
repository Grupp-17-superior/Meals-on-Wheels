using System;
using System.Collections.Generic;
using System.Text;
namespace MealsOnWheels;

public class ConsoleMenu
{
    RestaurantService _restaurantService;

    public ConsoleMenu(RestaurantService restaurants)
    {
        _restaurantService = restaurants;
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
        while (true)
        {
            Console.WriteLine("Välj en vara");
            for (int i = 0; i < restaurant.Menu.Count; i++)
            {
                Console.WriteLine($"{i + 1} {restaurant.Menu[i].Name}");
            }
            char choice = Console.ReadKey(true).KeyChar;
            List<OrderItems> items = new List<OrderItems>();
            items.Add(choice );
            break;
        }

    }
}
