using System;
using System.Collections.Generic;
using System.Text;

namespace MealsOnWheels.Payment
{

    public class PaymentService
    {
        public bool ProcessPayment(IPaymentStrategy paymentStrategy, decimal amount)
        {
            if (amount <= 0)
                return false;

            return paymentStrategy.Pay(amount);
        }
    }

}
