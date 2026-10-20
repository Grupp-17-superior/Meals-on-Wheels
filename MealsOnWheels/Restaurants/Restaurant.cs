namespace MealsOnWheels;

public class Restaurant : IOrderObserver
{
	public int RestaurantId { get; set; }
	public string Name { get; set; }
	public string Address { get; set; }
	public string PhoneNumber { get; set; }

	//restaurangens egna regler 
    public decimal MinimumOrderAmount { get; set; }
    public int EstimatedDeliveryTime { get; set; }

    // Restaurangens meny (lista på rätter/produkter)
    public List<MenuItem> Menu { get; set; } = new List<MenuItem>();

    // Lista på aktiva beställningar hos restaurangen

	public Restaurant(int restaurantId, string name, string address, string phoneNumber, decimal minimumOrderAmount, int estimatedDeliveryTime)
	{
        RestaurantId = restaurantId;
		Name = name;
		Address = address;
		PhoneNumber = phoneNumber;
        MinimumOrderAmount = minimumOrderAmount;
        EstimatedDeliveryTime = estimatedDeliveryTime;
	}

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
		Console.WriteLine($"[Restaurang {Name}] Notis: Order #{order.orderId} har nu status: {order.GetState()}");

		// Exempel på logik baserat på orderns status:
		// Om ordern är mottagen kan restaurangen t.ex. börja tillaga maten
	}
}