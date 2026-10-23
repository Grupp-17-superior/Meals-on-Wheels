namespace MealsOnWheels;

public class Restaurant(int restaurantId, string name, string address, string phoneNumber, decimal minimumOrderAmount, int estimatedDeliveryTime) : IOrderObserver
{
    public int RestaurantId { get; set; } = restaurantId;
    public string Name { get; set; } = name;
    public string Address { get; set; } = address;
    public string PhoneNumber { get; set; } = phoneNumber;

    public string status { get; private set; }
    //restaurangens egna regler 
    public decimal MinimumOrderAmount { get; set; } = minimumOrderAmount;
    public int EstimatedDeliveryTime { get; set; } = estimatedDeliveryTime;

    // Restaurangens meny (lista på rätter/produkter)
    public List<MenuItem> Menu { get; set; } = new List<MenuItem>();

    // Lista på aktiva beställningar hos restaurangen
    //Behöver restaurangen hålla koll på alla aktiva ordrar? Eller ska det skötas av OrderService?
    public List<Order> ActiveOrders { get; set; } = new List<Order>();

    // kontroll för minsta order som just nu kontrolleras före rabatt
    public bool MeetsMinimumOrder(decimal orderTotal)
    {
        return orderTotal >= MinimumOrderAmount;
    }

    // Metod för att lägga till rätter i menyn
    public void AddMenuItem(MenuItem item)
	{
		Menu.Add(item);
	}

	// Metod för att ta bort rätter från menyn
	public void RemoveMenuItem(MenuItem item)
	{
		Menu.Remove(item);
	}

	// Implementering av Observer Pattern:
	// Anropas när statusen på en order ändras (NotifyObservers())
	public void Update(Order order)
	{
		status = order.GetState();
    }
}