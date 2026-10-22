using MealsOnWheels.Customers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MealsOnWheels;

public class CheckoutMenu
{
    StrategyMenu strategyMenu = new StrategyMenu();
    CustomerController customerController;
    OrderController orderController;
    IDiscountStrategy strategy = new NoDiscount();

    public CheckoutMenu(OrderController orderController, CustomerController customerController)
    {
        this.orderController = orderController;
        this.customerController = customerController;
    }


    public bool Menu(Restaurant restaurant, List<OrderItems> items)
    {
        while (true)
        {
            Console.WriteLine("1. Fortsätt till kassan");
            Console.WriteLine("2. Rabatter");
            Console.WriteLine("3. Tillbaka till restaurangen");
            Console.WriteLine("4. Avsluta");

            char choice = Console.ReadKey(true).KeyChar;


            switch (choice)
            {
                case '1':
                    Customer customer = customerController.RegisterCustomer();
                    Order order = orderController.CreateOrder(customer, restaurant, items);
                    orderController.ProcessPayment(order, strategy);
                    return true;

                case '2':
                    strategy = strategyMenu.SelectStrategy();
                    break;

                case '3':
                    return false;

                case '4':
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Ogiltigt val. Försök igen.");
                    break;
            }
        }
    }

}
