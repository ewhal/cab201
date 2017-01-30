using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tempconv
{
    class Program
    {
        static void Main(string[] args)
        {
            double temp;
            Console.WriteLine("Enter Temperature in Fahrenheit: ");
            temp = double.Parse(Console.ReadLine());
            temp = (5.0 / 9.0) * (temp - 32);

            Console.WriteLine("\r\n" + temp.ToString("#.00") + " C");
            Console.Write("Hit any key to exit");
            Console.ReadKey();
        }
    }
}
