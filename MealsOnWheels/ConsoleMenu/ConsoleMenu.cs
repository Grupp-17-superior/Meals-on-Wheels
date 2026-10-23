using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
namespace MealsOnWheels;

public class ConsoleMenu
{
    private RestaurantService _restaurantService;
    private CheckoutMenu _checkoutMenu;
    private OrderController _orderController; // 1. Deklarera fältet

    // 2. Lägg till OrderController i konstruktorn
    public ConsoleMenu(RestaurantService restaurants, CheckoutMenu checkoutMenu, OrderController orderController)
    {
        _restaurantService = restaurants;
        _checkoutMenu = checkoutMenu;
        _orderController = orderController;
    }
     
    public void StartMenu()
    {
        while (true)
        {
            Console.Clear();
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
                        Console.Clear();
                        RestaurantsMenu();
                        break;
                    }
                case '2':
                    {
                        Console.Clear();
                        SearchOrderById();
                        break;
                    }

                case '3':
                    { 
                        Console.Clear();
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
                Console.Clear();
                bool completed = ShowMenu(restaurants[index]);
                if (completed)
                    break;
            }
            else
            {
                Console.WriteLine("Oglitigt val");
                Thread.Sleep(2000);
                Console.Clear();
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
                Console.Clear();
                Console.WriteLine("Hur många vill du ha?");
                if (int.TryParse(Console.ReadLine(), out selectedAmount) && selectedAmount > 0)
                {
                    Console.Clear();
                    OrderItems orderItems = new OrderItems(selectedItem, selectedAmount);
                    Cartitems.Add(orderItems);
                    Console.WriteLine($"{selectedAmount}st {selectedItem.Name}");
                    Thread.Sleep(2000);
                    Console.Clear();
                }

                else
                {
                    Console.WriteLine("Ogiltigt antal");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
            }
            else if (choice == '0')
            {
                Console.Clear();
                bool completed = _checkoutMenu.Menu(restaurant, Cartitems);
                if (completed)
                    return true;
            }

            else
            {
                Console.WriteLine("Oglitigt val");
                Thread.Sleep(2000);
                Console.Clear();
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
                Console.Clear();
                Console.WriteLine($"Order hittad! Order-ID: {order.orderId}");
                Thread.Sleep(2000);

            }
            else
            {
                Console.WriteLine($"Ingen order hittades med ID {searchId}.");
                Thread.Sleep(2000);
                Console.Clear();
            }
        
        }
    }
}
