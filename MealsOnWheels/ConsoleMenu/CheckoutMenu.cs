using System;
using System.Collections.Generic;
using System.Text;

namespace MealsOnWheels;

public class CheckoutMenu
{
    StrategyMenu strategyMenu = new StrategyMenu();
    CustomerService customerService;
    OrderController orderController;
    IDiscountStrategy? strategy;

    public CheckoutMenu(OrderController orderController, CustomerService customerService)
    {
        this.orderController = orderController;
        this.customerService = customerService;
    }


    public void Menu(Restaurant restaurant, List<OrderItems> items)
    {
        Console.WriteLine("1. Fortsätt till kassan");
        Console.WriteLine("2. Rabatter");
        Console.WriteLine("3. Tillbaka till restaurangen");
        Console.WriteLine("4. Avsluta");

        char choice = Console.ReadKey(true).KeyChar;
        
        switch (choice)
        {
            case '1':
                Customer customer = customerService.CreateCustomer();
                Order order = orderController.CreateOrder(customer, restaurant, items);
                orderController.ProcessPayment(order, strategy);
                break;

            case '2':
                strategy = strategyMenu.SelectStrategy();
                break;

            case '3':
                checkoutMenu;
                return;

            case '4':
                Environment.Exit(0);
                break;

            default:
                Console.WriteLine("Ogiltigt val. Försök igen.");
                break;
        }
    }

}
