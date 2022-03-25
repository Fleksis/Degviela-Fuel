using System;

namespace C_fuel_station {
    class Program {
        public static void Main(string[] args) {
            double gasolinePrice = 1.5;
            double dieselPrice = 1.1;
            bool userGasoline = false;
            bool userDiesel = false;

            double PriceGasoline = 0;
            double PriceDiesel = 0;

            Console.Write("What fuel type to fill: ");
            string fuelType = Console.ReadLine().ToLower();
            if (fuelType == "gasoline") {
                userGasoline = true;
                Gasoline gasolineSample = new Gasoline("Gasoline", 0, ref gasolinePrice, userGasoline);
                gasolineSample.Fuel_Status(ref PriceGasoline);
                gasolineSample = null;
            } else if (fuelType == "diesel") {
                userDiesel = true;
                Diesel dieselSample = new Diesel("Diesel", 0, ref dieselPrice, userDiesel);
                dieselSample.Fuel_Status(ref PriceDiesel);
                dieselSample = null;
               
            } else {
                Console.WriteLine("Unknow type of fuel");
                return;
            }

            Console.Write($"How much fill fuel of {fuelType}: ");
            double fuelAmount = Convert.ToDouble(Console.ReadLine());

            Console.ReadKey();
            Console.Clear();

            Gasoline gasoline = new Gasoline("Gasoline", fuelAmount, ref gasolinePrice, userGasoline);
            Diesel diesel = new Diesel("Diesel", fuelAmount, ref dieselPrice, userDiesel);

            
            FuelStation fuelObj;

            fuelObj = gasoline;
            bool fuelable = fuelObj.Is_fuelable();
            if (fuelable == false && userGasoline == true) {
                return;
            }
            fuelObj.Fuel_Status(ref PriceGasoline);

            fuelObj = diesel;
            if (fuelObj.Is_fuelable() == false && userDiesel == true) {
                return;
            }
            fuelObj.Fuel_Status(ref PriceDiesel);

            if (gasoline.UserFuelType == true) {
                gasoline.Difference(ref PriceGasoline, ref PriceDiesel);
            } else if (diesel.UserFuelType == true) {
                diesel.Difference(ref PriceGasoline, ref PriceDiesel);
            }

            Console.ReadKey();
        }
    }
}
