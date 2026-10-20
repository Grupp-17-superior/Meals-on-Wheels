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

        pizzeria.AddMenuItem(new MenuItem("Margherita", 10.99m));
        _restaurants.Add(pizzeria);
    }

    public List<Restaurant> GetRestaurants()
    {
        return _restaurants;
    }
}
