using System;
using System.Collections.Generic;
using System.Text;
namespace MealsOnWheels;

public class CheckoutMenu
{
    StrategyMenu strategyMenu = new StrategyMenu();
    CustomerController customerController;
    OrderService orderService;
    PaymentService paymentService = new PaymentService();
    IDiscountStrategy strategy = new NoDiscount();

    public CheckoutMenu(OrderService orderService, CustomerController customerController, PaymentService paymentService)
    {
        this.orderService = orderService;
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

                        Order? order = orderService.CreateOrder(customer, restaurant, items);
                        
                    

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


                        IPaymentStrategy paymentStrategy;
                        while (true)
                        {

                            // välj betalningsmetod
                            Console.WriteLine("\nVälj betalningsmetod:");
                            Console.WriteLine("1. Kort");
                            Console.WriteLine("2. Swosh");

                            string paymentChoice = Console.ReadLine() ?? "";

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
                                    continue;
                            }
                            break;
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
