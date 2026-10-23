using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
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
            Console.WriteLine("Välkommen till Meals on Wheels!");
            Console.WriteLine("Välj ett alternativ");
            Console.WriteLine("1. Visa restauranger");
            Console.WriteLine("2. Kolla status");
            Console.WriteLine("3. Avsluta");

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
                        Environment.Exit(0);
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
            Console.WriteLine($"--- {restaurant.Name} Meny ---\n");

            Console.WriteLine($"Telefon: {restaurant.PhoneNumber} | Adress: {restaurant.Address}");
            Console.WriteLine($"Minsta orderbelopp: {restaurant.MinimumOrderAmount} kr | Leveranstid: {restaurant.EstimatedDeliveryTime} min\n");

            for (int i = 0; i < restaurant.Menu.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {restaurant.Menu[i].Name} ({restaurant.Menu[i].Price} kr)");
            }
            Console.WriteLine("0. Gå till checkout");
            Console.WriteLine("B. Gå tillbaka till restaurangval"); // Nytt menyval

            char choice = Console.ReadKey(true).KeyChar;
            int index = choice - '1';

            if (index >= 0 && index < restaurant.Menu.Count)
            {
                var selectedItem = restaurant.Menu[index];
                Console.Clear();
                Console.WriteLine($"Vald vara: {selectedItem.Name}");
                Console.Write("Hur många vill du ha? ");

                if (int.TryParse(Console.ReadLine(), out int selectedAmount) && selectedAmount > 0)
                {
                    Console.Clear();
                    OrderItems orderItems = new OrderItems(selectedItem, selectedAmount);
                    Cartitems.Add(orderItems);

                    Console.WriteLine($"Lade till {selectedAmount}st {selectedItem.Name} i varukorgen.\n");

                    // Undermeny efter genomfört val
                    bool waitingForChoice = true;
                    while (waitingForChoice)
                    {
                        Console.WriteLine("Vad vill du göra nu?");
                        Console.WriteLine("1. Fortsätta handla (återgå till menyn)");
                        Console.WriteLine("2. Gå till checkout");

                        char subChoice = Console.ReadKey(true).KeyChar;
                        if (subChoice == '1')
                        {
                            waitingForChoice = false;
                            Console.Clear();
                        }
                        else if (subChoice == '2')
                        {
                            Console.Clear();
                            bool completed = _checkoutMenu.Menu(restaurant, Cartitems);
                            if (completed)
                                return true;

                            waitingForChoice = false; // Om checkout avbryts/misslyckas återgår vi till loopen
                        }
                        else
                        {
                            Console.WriteLine("Ogiltigt val, försök igen.\n");
                        }
                    }
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
            else if (char.ToUpper(choice) == 'B') // Hanterar både 'b' och 'B'
            {
                Console.Clear();
                return false; // Returnerar false för att gå tillbaka till restaurangvalet
            }
            else
            {
                Console.WriteLine("Ogiltigt val");
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
                Console.WriteLine($"Restaurang: {order.restaurant.Name}");
                Console.WriteLine($"Kund: {order.customer.Name}");
                //Console.WriteLine($"Adress: {order.customer.address}");
                //Console.WriteLine($"selected items selected amount: {order.orderItems.Count}");
                Console.WriteLine($"Status: {order.GetState()}");
                Console.WriteLine($"Totalpris: {order.CalculateFinalPrice()} kr");

                Console.WriteLine("\nTryck på valfri tangent för att återgå till huvudmenyn");
                Console.ReadKey(true);

            }
            else
            {
                Console.WriteLine($"Ingen order hittades med ID {searchId}.");
                
                Console.WriteLine("\nTryck på valfri tangent för att återgå till huvudmenyn");
                Console.ReadKey(true);
            }
        
        }
    }
}
