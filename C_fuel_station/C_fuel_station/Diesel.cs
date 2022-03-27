using System;

namespace C_fuel_station {
    class Diesel : FuelStation {
        public Diesel(string fuelType, ref int stationFuelAmount, double fuelAmount, ref double pricePerLiter, bool isOrder = false) : base() {
            this.FuelType = fuelType;
            this.StationFuelAmount = stationFuelAmount;
            this.FuelAmount = fuelAmount;
            this.PricePerLiter = pricePerLiter;
            this.IsOrder = isOrder;
        }

        public override void Station_order(ref double Price) {
            this.Choice();
            string data = string.Format("{0,-14} {1, -24} {2, -19} {3, -19}\n", "Fuel Type", "Fuel in station", "Fill amount", "price per liter");
            data += string.Format("{0,-15} {1,-25} {2,-20} {3,-20}", this.FuelType, $"{this.StationFuelAmount}L", $"{this.FuelAmount}L", $"{this.PricePerLiter}EUR/L");
            Console.WriteLine(data);

            Price = this.FuelAmount * this.PricePerLiter;

            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public override void Receipt(ref double Price) {
            Random rnd = new Random();
            Console.WriteLine("+ - - - - - - - - - - - - - - - - - - - - - - - - + ");
            string NesteData = string.Format("{0,-24}{1,-26}{2,0}", "|", "Neste Oil Riga", "|\n");
            NesteData += string.Format("{0,0} {1,-47} {2,0}", "|", $"Receipt number - {rnd.Next(100000, 999999)}", "|\n");
            NesteData += string.Format("{0,0} {1,-47} {2,0}", "|", "NESTE LATVIJA SIA", "|\n");
            NesteData += string.Format("{0,0} {1,-47} {2,0}", "|", "Dzirnavu iela 127", "|\n");
            NesteData += string.Format("{0,0} {1,-47} {2,0}", "|", "Latgales priekšpilsēta, Riga, LV-1050", "|\n");
            NesteData += string.Format("{0,-49} {1,0}", "|", "|");
            Console.WriteLine(NesteData);
            Console.WriteLine("+ - - - - - - - - - - - - - - - - - - - - - - - - + ");

            string UserData = string.Format("{0,0} {1,-43} {2,6}", "|", $"Order date - {DateTime.Now}", "|\n");
            UserData += string.Format("{0,-49} {1,0}", "|", "|\n");
            UserData += string.Format("{0,0} {1,-19} {2,-13} {3,-12} {4,0}", "|", this.FuelType, $"{this.FuelAmount}L", $"{Price}EUR", " |\n");
            UserData += string.Format("{0,0} {1,-19} {2,-27} {3,0}", "|", $"fuel Pump-{rnd.Next(1, 3)}", $"{this.PricePerLiter}EUR/L", "|\n");
            UserData += string.Format("{0,-49} {1,0}", "|", "|\n");
            UserData += "+ - - - - - - - - - - - - - - - - - - - - - - - - + \n";
            UserData += string.Format("{0,0} {1,-33} {2,-13} {3,0}", "|", "Full price", $"{Price}EUR", "|\n");
            UserData += "+ - - - - -+- - - - + - - - - - - + - - - - - - - + \n";

            double VAT = 21.00;
            UserData += string.Format("{0,0} {1,-7} {2,-6} {3,-16} {4,-10} {5,0}", "|", "VAT-rate |", "  VAT  |", "Without VAT |", "With VAT", "|\n");
            UserData += string.Format("{0,0} {1,-9}{2,0} {3,-7}{4,0} {5,-12}{6,0} {7,-14}{8,0}", "|", $"{VAT}", "|", $"{Math.Round(Price*(VAT/100), 2)}", "|", $"{Math.Round(Price - (Price * (VAT / 100)), 2)}", "|", Price, "|\n");
            UserData += "+ - - - - -+- - - - + - - - - - - + - - - - - - - + \n";
            UserData += string.Format("{0,-14}{1,-36}{2,0}", "|", "Thanks you for purchase!", "|\n");
            UserData += string.Format("{0,-49} {1,0}", "|", "|\n");
            UserData += "+ - - - - - - - - - - - - - - - - - - - - - - - - + \n";
            Console.WriteLine(UserData);
        }

        public override void Difference(ref double PriceGasoline, ref double PriceDiesel) {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("-===== Order difference with other fuel type =====-");
            Console.WriteLine("Compared fuel types (Diesel and Gasoline)");

            if (PriceDiesel <= PriceGasoline) {
                Console.WriteLine($"You are saving on diesel: {(PriceDiesel - PriceGasoline)*-1}EUR");
            } else {
                Console.WriteLine($"You could save on gasoline: {PriceGasoline - PriceDiesel}EUR");
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

    }
}
