using System;

namespace C_fuel_station {
    abstract class FuelStation {
        protected string FuelType;
        protected double StationFuelAmount;
        protected double FuelAmount;
        protected double PricePerLiter;
        public bool IsOrder;

        abstract public void Station_order(ref double Price);
        abstract public void Difference(ref double PriceGasoline, ref double PriceDiesel);
        abstract public void Receipt(ref double Price);

        public void Choice() {
            if (this.IsOrder == true) {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("-=============================== Your order ===============================-");
            } else {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("-=============================== Other order ===============================-");
            }
        }

        public bool Is_fuelable() {
            if (this.FuelAmount > this.StationFuelAmount) {
                Console.WriteLine("Not enough fuel in station! ");
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
