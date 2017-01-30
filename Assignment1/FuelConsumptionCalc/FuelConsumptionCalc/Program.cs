using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelConsumptionCalc {
    /*
     * Calculates fuel consumption in l/100km and the equivalent mpg,
     * inputs units of measurement are litres(l) for fuel used and
     * kilometres (km) for distance travelled
     * Author Eliot, Whalan, n9446800
     * Date: August 2016
     */
    class Program {
        static void Main(string[] args) {
            string key;
            do {

                Welcome();    

                double litres = GetInput("Please enter fuel used in Litres: ", 20);
                double distance = GetInput("Please enter distance in kilometers: ", (litres * 8));

                double consumption = FuelConsumption(litres, distance);
                double mpg = LitresToMPG(consumption);

                PrintResults(consumption, mpg);

                key = GetKey();

            } while (key == "y" || key == "Y");

            ExitProgram();
        }

        static void Welcome() {
            Console.WriteLine("\n\tWelcome to Fuel Consumption Calculator\n\n");
        }

        static void PrintResults(double litres, double mpg) {
            Console.WriteLine("\nYour fuel consumption rate is {0}lt/100km", litres.ToString("#0.00"));
            Console.WriteLine("\n Which is equivalent to {0} mpg.\n", mpg.ToString("#0.00"));
        }

        static string GetKey() {
            Console.WriteLine("\nAnother calculation (Y/ N) : ");
            return Console.ReadLine();
        }

        static void ExitProgram() {
            Console.WriteLine("Press any key to exit... ");
            Console.ReadKey();
        }
        
        static double GetInput(string message, double  minValue) {
            bool ok;
            double value;
            do {
                Console.Write(message);
                ok = double.TryParse(Console.ReadLine(), out value);
                if (minValue > value) {
                    Console.WriteLine("\t{0} is below the minimum value of {1}", value, minValue);
                    ok = false;
                }
            } while (!ok);

            return value;
        }
        static double FuelConsumption(double consumption, double distance) {
            return ((consumption / distance) * 100);
        }

        static double LitresToMPG(double litres) {
            return 282.38 / litres;
        }
        
        
    }
}
