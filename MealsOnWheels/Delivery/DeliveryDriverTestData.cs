using System;
using System.Collections.Generic;
using System.Text;
namespace MealsOnWheels;

public static class DeliveryDriverTestData
{
    public static void AddTestDrivers(DeliveryService deliveryService)// skapar testbud och lägger dem i kön
    {
        deliveryService.AddAvailableDriver(
            new DeliveryDriver(1, "Carlito", "0701234567", "Cykel"));

        deliveryService.AddAvailableDriver(
            new DeliveryDriver(2, "Lorenzo Svensson", "0702345678", "Bil"));

        deliveryService.AddAvailableDriver(
            new DeliveryDriver(3, "Ciciliana", "0703456789", "Moped"));
    }
}
