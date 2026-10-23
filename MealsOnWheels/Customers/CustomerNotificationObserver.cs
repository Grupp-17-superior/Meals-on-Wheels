using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
namespace MealsOnWheels;
    public class CustomerNotificationObserver : IOrderObserver
    {
    private readonly Customer customer;
    public string status { get; private set; }

    public CustomerNotificationObserver(Customer customer)
        {
            this.customer = customer;
        }

        // Implementering av IOrderObserver
        public void Update(Order order)
        {
            status = order.GetState();
        }
    }
