using System;
using System.Collections.Generic;
using System.Text;

using System;
using MealsOnWheels;

namespace MealsOnWheels;

public class StrategyMenu
{
    public IDiscountStrategy SelectStrategy()
    {
        while (true)
        {
            Console.WriteLine("\n Välj Rabatt");
            Console.WriteLine("1. Ingen");
            Console.WriteLine("2. Fast Rabatt");
            Console.WriteLine("3. Rabatt %");
            Console.WriteLine("4. Student Rabatt");
            Console.Write("Välj (1-4): ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    return new NoDiscount();

                case "2":
                    decimal fixedAmount = PromptForDecimal("Fast Rabatt");
                    return new FixedDiscountStrategy(fixedAmount);

                case "3":
                    decimal percentage = PromptForDecimal("Rabatt %");
                    return new PercentageDiscount(percentage);

                case "4":
                    return new StudentDiscountStrategy();

                default:
                    Console.WriteLine("Ogiltigt val");
                    break;
            }
        }
    }

    private decimal PromptForDecimal(string prompt)
    {
        decimal value;
        do
        {
            Console.Write(prompt);
        } while (!decimal.TryParse(Console.ReadLine(), out value) || value < 0);

        return value;
    }
}
