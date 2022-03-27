using System;

namespace C_fuel_station {
    class Diesel : FuelStation {
        public Diesel(string fuelName, ref int stationFuelAmount, double fuelAmount, ref double pricePerLiter, bool userFuelType = false) : base() {
            this.FuelName = fuelName;
            this.StationFuelAmount = stationFuelAmount;
            this.FuelAmount = fuelAmount;
            this.PricePerLiter = pricePerLiter;
            this.UserFuelType = userFuelType;
        }

        public override void Fuel_Status(ref double Price) {
            this.Choice();
            Console.WriteLine($"Fuel type: {this.FuelName}");
            Console.WriteLine($"Station fuel amount: {this.StationFuelAmount - this.FuelAmount} Liters");
            Console.WriteLine($"Fill amount: {this.FuelAmount} Liters");
            Console.WriteLine($"Fuel price per liter: {this.PricePerLiter}EUR\n");

            Price = this.FuelAmount * this.PricePerLiter;

            Console.WriteLine($"Fuel price is: {Price}EUR");
            Console.WriteLine("-==========================================-\n");
        }

        public override void Difference(ref double PriceGasoline, ref double PriceDiesel) {
            Console.WriteLine("diesel-============== Order difference with other fuel type ==============-");
            Console.WriteLine("Compared fuel types (Diesel and Gasoline)");

            if (PriceDiesel <= PriceGasoline) {
                Console.WriteLine($"You are saving on diesel: {(PriceDiesel - PriceGasoline)*-1}EUR");
            } else {
                Console.WriteLine($"You could save on gasoline: {PriceGasoline - PriceDiesel}EUR");
            } 
        }
    }
}
