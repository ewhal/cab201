using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            double income;
            int children;
            bool okay;

            Console.WriteLine("Tax Calculator");

            do {
                Console.Write("Enter your annual income: ");
                string inputIncome = Console.ReadLine();
                okay = double.TryParse(inputIncome, out income) && income >= 0;

                if (!okay) {
                    Console.WriteLine("\nError invalid input");
                }
                

            } while (!okay);

            do {

                Console.Write("How many children do you have?: ");
                string inputChildren = Console.ReadLine();
                okay = int.TryParse(inputChildren, out children) && children >= 0;

                if (!okay) {
                    Console.WriteLine("\nError invalid input");
                }
            } while (!okay);

            double deductions = 10000 + (2000 * children);
            double tax = (income - deductions)  * 0.2;
            if (tax <= 0 ) {
                Console.WriteLine("No tax to be paid.");
            } else {
                Console.WriteLine("Tax to be paid: " + tax);
            }

            Console.WriteLine("Press any key to continue . . .");
            Console.ReadLine();


        }
    }
}
