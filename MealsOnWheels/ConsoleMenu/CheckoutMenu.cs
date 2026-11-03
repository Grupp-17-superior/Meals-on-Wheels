using System;
using System.Collections.Generic;
using System.Text;
namespace MealsOnWheels;

public class CheckoutMenu
{
    StrategyMenu strategyMenu = new StrategyMenu();
    CustomerController customerController;
    OrderController orderController;
    PaymentService paymentService = new PaymentService();
    IDiscountStrategy strategy = new NoDiscount();

    public CheckoutMenu(OrderController orderController, CustomerController customerController, PaymentService paymentService)
    {
        this.orderController = orderController;
        this.customerController = customerController;
        this.paymentService = paymentService;
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
                    {
                        Customer customer = customerController.RegisterCustomer();

                        Order? order = orderController.CreateOrder(customer, restaurant, items);
                        
                    

                        if (order == null)
                        {
                            Console.WriteLine("Ordern kunde inte skapas. Försök igen.");
                            Thread.Sleep(2000);
                            Console.Clear();
                            break;
                        }

                        //applicerar den valda rabattstrategin
                        order.SetDiscountStrategy(strategy);
                        decimal total = order.CalculateFinalPrice();

                        Console.WriteLine($"\nAtt betala: {total}kr");

                        // välj betalningsmetod
                        
                        Console.WriteLine("\nVälj betalningsmetod:");
                        Console.WriteLine("1. Kort");
                        Console.WriteLine("2. Swosh");

                        string paymentChoice = Console.ReadLine() ?? "";

                        IPaymentStrategy paymentStrategy;

                        switch (paymentChoice)
                        {
                            case "1":
                                paymentStrategy = new CardPayment();
                                break;

                            case "2":
                                paymentStrategy = new SwoshPayment();
                                break;

                            default:
                                Console.WriteLine("Ogiltigt val av betalningsmetod.");
                                Thread.Sleep(2000);
                                Console.Clear();
                                return false;
                        }

                        bool paymentSuccess = paymentService.ProcessPayment(paymentStrategy, total);

                        if (paymentSuccess)
                        {
                            Console.Clear();
                            Console.WriteLine("Betalning lyckades! Tack för din beställning.");

                            Console.WriteLine($"Ditt order-ID är: {order.orderId}"); //Skriver nu ut Order-ID efter att ordern har skapats

                            _ = order.ProcessOrderAsync();
                            Thread.Sleep(4000);
                            return true;
                        }
                        Console.Clear();
                        Console.WriteLine("Betalning misslyckades. Försök igen.");
                        Thread.Sleep(4000);
                        Console.Clear();
                        break;
                    }

                case '2':
                    strategy = strategyMenu.SelectStrategy();
                    break;

                case '3':
                    return false;

                case '4':
                    Environment.Exit(0);
                    return false;

                default:
                    Console.WriteLine("Ogiltigt val. Försök igen.");
                    Thread.Sleep(2000);
                    Console.Clear();
                    break;
            }
        }
    }

}
