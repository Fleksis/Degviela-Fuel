using System;

namespace C_fuel_station {
    class Program {
        static public void Any_key() {
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }

        public static void Main(string[] args) {
            double gasolinePrice = 1.5;
            double dieselPrice = 1.1;
            Random rnd = new Random();
            int stationFuelAmount = rnd.Next(300);
            bool userGasoline = false;
            bool userDiesel = false;

            double PriceGasoline = 0;
            double PriceDiesel = 0;

            Console.Write("What fuel type to fill: ");
            string fuelType = Console.ReadLine().ToLower();
            if (fuelType == "gasoline") {
                userGasoline = true;
                Gasoline gasolineSample = new Gasoline("Gasoline", ref stationFuelAmount, 0, ref gasolinePrice, userGasoline);
                gasolineSample.Fuel_Status(ref PriceGasoline);
                gasolineSample = null;
            } else if (fuelType == "diesel") {
                userDiesel = true;
                Diesel dieselSample = new Diesel("Diesel", ref stationFuelAmount, 0, ref dieselPrice, userDiesel);
                dieselSample.Fuel_Status(ref PriceDiesel);
                dieselSample = null;
               
            } else {
                Console.WriteLine("Unknow type of fuel");
                return;
            }

            Console.Write($"How much fill fuel of {fuelType}: ");
            double fuelAmount = Convert.ToDouble(Console.ReadLine());

            Any_key();
            //Console.Clear();

            Gasoline gasoline = new Gasoline("Gasoline", ref stationFuelAmount, fuelAmount, ref gasolinePrice, userGasoline);
            Diesel diesel = new Diesel("Diesel", ref stationFuelAmount, fuelAmount, ref dieselPrice, userDiesel);

            
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

            Any_key();

            if (gasoline.UserFuelType == true) {
                gasoline.Difference(ref PriceGasoline, ref PriceDiesel);
            } else if (diesel.UserFuelType == true) {
                diesel.Difference(ref PriceGasoline, ref PriceDiesel);
            }

            Any_key();
        }
    }
}
