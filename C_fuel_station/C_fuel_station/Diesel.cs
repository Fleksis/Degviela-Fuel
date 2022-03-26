using System;

namespace C_fuel_station {
    class Diesel : FuelStation {
        public Diesel(string fuelName, double fuelAmount, ref double pricePerLiter, bool userFuelType = false) : base() {
            this.FuelName = fuelName;
            Random rnd = new Random();
            this.BaseFuelAmount = rnd.Next(300);
            this.FuelAmount = fuelAmount;
            this.PricePerLiter = pricePerLiter;
            this.UserFuelType = userFuelType;
        }

        public override void Fuel_Status(ref double Price) {
            this.Choice();
            Console.WriteLine($"Fuel type: {this.FuelName}");
            Console.WriteLine($"Station fuel amount: {this.BaseFuelAmount} Liters");
            Console.WriteLine($"Fill amount: {this.FuelAmount} Liters");
            Console.WriteLine($"Fuel price per liter: {this.PricePerLiter}EUR\n");

            Price = this.FuelAmount * this.PricePerLiter;

            Console.WriteLine($"Fuel price is: {Price}EUR");
            Console.WriteLine("-==========================================-\n");
        }

        public override void Difference(ref double PriceGasoline, ref double PriceDiesel) {
            Console.WriteLine("-============== Order difference with other fuel type ==============-");
            Console.WriteLine("Compared fuel types (Diesel and Gasoline)");

            if (PriceDiesel >= PriceGasoline) {
                Console.WriteLine($"You save with diesel: {PriceDiesel - PriceGasoline}EUR");
            } else {
                Console.WriteLine($"You may save with gasoline: {PriceGasoline - PriceDiesel}EUR");
            } 
        }
    }
}
