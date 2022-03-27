using System;

namespace C_fuel_station {
    abstract class FuelStation {
        protected string FuelName;
        protected double StationFuelAmount;
        protected double FuelAmount;
        protected double PricePerLiter;
        public bool UserFuelType;

        abstract public void Fuel_Status(ref double Price);
        abstract public void Difference(ref double PriceGasoline, ref double PriceDiesel);

        public void Choice() {
            if (this.UserFuelType == true) {
                Console.WriteLine("-============== Your order ==============-");
            }
            else {
                Console.WriteLine("-============== Other order ==============-");
            }
        }

        public bool Is_fuelable() {
            if (this.FuelAmount > this.StationFuelAmount) {
                Console.WriteLine("Not enough fuel in station!");
                Console.ReadKey();
                return false;
            } else if (this.StationFuelAmount < 50) {
                Console.WriteLine("Station fuel is almost empty, wait till it will filled.");
                Console.ReadKey();
                return false;
            } else {
                return true;
            }
        }
    }
}
