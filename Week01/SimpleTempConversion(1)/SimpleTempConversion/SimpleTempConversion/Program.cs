using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleTempConversion {
    /* Class to convert Celsius temperature to Fahrenheit
     * Author ....
     * Date: July 2015
     */
    class Convert {
        static void Main() {
            double celsius = 0.0;
            
            //input the temperature in degrees Celsius
            Console.Write("Enter degrees Celsius: ");
            celsius = int.Parse(Console.ReadLine());

           // Calculate degrees Fahrenheit and output the result
            Console.WriteLine("\n\nThe equivalent in Fahrenheit is " + (celsius/5 * 9 + 32));

            Console.Write("\n\n Hit Enter to exit.");
            Console.ReadKey();
        }
    }
}
