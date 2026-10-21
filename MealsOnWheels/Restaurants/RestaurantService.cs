using System;
using System.Collections.Generic;
using System.Text;
namespace MealsOnWheels;

public class RestaurantService
{
    private List<Restaurant> _restaurants = new();

    // Exempel på att Skapa restauranger och deras menyer så vi slipper att kladda i main
    public void CreateRestaurant()
    {

        
        // 1. Swedish Pizzeria
        Restaurant pizzeria = new Restaurant(1, "Isaks pannpizza", "lökgatan 28", "07667676767", 200m, 30);
        pizzeria.AddMenuItem(new MenuItem("Kebabpizza", 110.98m));
        pizzeria.AddMenuItem(new MenuItem("Pizza med allt", 140.00m));
        pizzeria.AddMenuItem(new MenuItem("Vulcano", 130.00m));
        pizzeria.AddMenuItem(new MenuItem("Festis Lök Rabarber", 30.00m));
        pizzeria.AddMenuItem(new MenuItem("Läsk bea mynta", 40.00m));
        pizzeria.AddMenuItem(new MenuItem("Cola coka", 40.00m));
        _restaurants.Add(pizzeria);

        // 2. Exklusiva Resturangen Fine Dining 
        Restaurant finedining = new Restaurant(2, "Sofias Kräftskiva", "Grensjön 67", "0766969696", 500, 45);
        finedining.AddMenuItem(new MenuItem("Salmon Nigiri (2pcs)", 299.50m));
        finedining.AddMenuItem(new MenuItem("California lobster Roll (8pcs)", 399.99m));
        finedining.AddMenuItem(new MenuItem("Surstömming soppa", 300.00m));
        finedining.AddMenuItem(new MenuItem("Kopi Luwak", 55.00m));
        finedining.AddMenuItem(new MenuItem("Cotton Candy Margarita", 120.00m));
        finedining.AddMenuItem(new MenuItem("Monkey 47 Gyn", 180.00m));
        _restaurants.Add(finedining);

        // 3. Calles Burgare
        Restaurant burger = new Restaurant(3, "Calles Burgare", "Highway to hell 666", "07694206667", 200, 30);
        burger.AddMenuItem(new MenuItem("Cheese with cheese", 80.99m));
        burger.AddMenuItem(new MenuItem("Best friends bacon burger", 110.49m));
        burger.AddMenuItem(new MenuItem("Sweet Brotato", 40.50m));
        burger.AddMenuItem(new MenuItem("Mjölk med kolsyra", 20.00m));
        burger.AddMenuItem(new MenuItem("Soadastream", 20.00m));
        burger.AddMenuItem(new MenuItem("Veckans Öl", 40.00m));
        _restaurants.Add(burger);
        
       
    }

    public List<Restaurant> GetRestaurants()
    {
        return _restaurants;
    }
}
