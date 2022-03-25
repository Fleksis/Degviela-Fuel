using System;

namespace C_fuel_station {
    class Gasoline : FuelStation {
        public Gasoline(string fuelName, double fuelAmount, ref double pricePerLiter, bool userFuelType = false) : base() {
            this.FuelName = fuelName;
            this.BaseFuelAmount = 282;
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
            Console.WriteLine($"Difference: {PriceGasoline - PriceDiesel}");

        }

    }
}
