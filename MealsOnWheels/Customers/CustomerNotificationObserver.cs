using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace MealsOnWheels.Customers
{
    public class CustomerNotificationObserver : IOrderObserver
    {
        private readonly Customer customer;

        public CustomerNotificationObserver(Customer customer)
        {
            this.customer = customer;
        }

        // Implementering av IOrderObserver
        public void Update(Order order)
        {
            string status = order.GetState();

            // anpassade meddelanden beroende på status
            switch (status)
            {
                case "Mottagen":
                    Console.WriteLine($"[Kund {customer.GetName()}] Din order #{order.orderId} " +
                $"hos {order.restaurant.Name} har tagits emot");
                    break;

                case "Förbereder":
                    Console.WriteLine(
                        $"[Kund {customer.GetName()}], din mat tillagas av {order.restaurant.Name}");
                    break;
                case "Levererar":
                    Console.WriteLine("Budet är på väg med din mat!");
                    break;

                case "Levererad":
                    Console.WriteLine($"[Kund {customer.GetName()}] Din mat har levererats, Smaklig måltid!");
                    break;
                case "Avbruten":
                    Console.WriteLine($"[Kund {customer.GetName()}] Din order #{order.orderId} har blivit avbruten.");
                    break;
            }
        }
    }
}
