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
        Restaurant pizzeria = new Restaurant(1, "Pizzeria", "123 Main St", "555-1234");

        
        // 1. Swedish Pizzeria
        Restaurant pizzeria = new Restaurant(1, "Isaks pannpizza", "lökgatan 28", "555-1234", 200m, 30);
        pizzeria.AddMenuItem(new MenuItem("Kebabpizza", 110.98m));
        pizzeria.AddMenuItem(new MenuItem("Pizza med allt", 140.00m));
        pizzeria.AddMenuItem(new MenuItem("Vulcano", 130.00m));
        _restaurants.Add(pizzeria);

        // 2. Exklusiva Resturangen Fine Dining 
        Restaurant finedining = new Restaurant(2, "Sofias Kräftskiva", "Grensjön 67", "555-5678", 500, 45);
        finedining.AddMenuItem(new MenuItem("Salmon Nigiri (2pcs)", 299.50m));
        finedining.AddMenuItem(new MenuItem("California lobster Roll (8pcs)", 399.99m));
        finedining.AddMenuItem(new MenuItem("Surstömming soppa", 300.00m));
        _restaurants.Add(finedining);

        // 3. Calles Burgare
        Restaurant burger = new Restaurant(3, "Calles Burgare", "Highway to hell 666", "555-9012", 200, 30);
        burger.AddMenuItem(new MenuItem("Cheese with cheese", 80.99m));
        burger.AddMenuItem(new MenuItem("Best friends bacon burger", 110.49m));
        burger.AddMenuItem(new MenuItem("Sweet Brotato", 40.50m));
        _restaurants.Add(burger);
        
       
    }

    public List<Restaurant> GetRestaurants()
    {
        return _restaurants;
    }
}
