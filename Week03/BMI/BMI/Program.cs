using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMI {
    class Program {
        static void Main(string[] args) {
            const int MIN_WAIST = 60;
            const int MIN_HEIGHT = 120;
            double waist;
            double height;
            int gender;
            string key;

            Console.WriteLine("\t\tWelcome to Waist to Height ratio Calculator");
            
            do {
                
                waist = GetInput("waist", MIN_WAIST);
                height = GetInput("height", MIN_HEIGHT);

                gender = GetGender();

                Bmi(waist, height, gender);

                Console.WriteLine("Another calculation <Enter Y or N>: ");
                key = Console.ReadLine();
                    
            } while (key == "Y" || key == "y" );
        }

        public static double GetInput(string type, int minValue) {
            double output;
            bool ok;
            do {
                Console.Write("Enter {0} in cms (Above {1}): ", type, minValue);
                
                ok = double.TryParse(Console.ReadLine(), out output);

            } while (!ok || output < minValue);

            return output;
        }
        public static int GetGender() {
            int gender;
            bool ok;
            do {
                Console.Write("Are you\n" +
                    "\t0) Male\n" +
                    "\t1) Female\n" +
                    "\tEnter your option < 0 or 1 >: ");
                ok = int.TryParse(Console.ReadLine(), out gender);
            } while (!ok);
            return gender;
        }

        public static void Bmi(double waist, double height, int gender) {
            double ratio = waist / height;
            Console.WriteLine("Your weight to height ratio is: " + ratio);
            if ((ratio < 0.492 && gender == 1) || (ratio < 0.536 && gender == 0)) {
                Console.WriteLine("You are at a low risk of cardiovascular disease");
            } else {
                Console.WriteLine("You are at a high risk of cardiovascular disease");
            }
        }
    }
}
