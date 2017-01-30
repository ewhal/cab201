using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            string eyeColour;
            int height;
            int age;

            Console.WriteLine("Please enter your name: ");
            name = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Please enter your eye colour: ");
            eyeColour = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Please enter your height: ");
            height = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Please enter your age: ");
            age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("hello " + name + " with the colour eyes: " + eyeColour + " Height: " + height + " cms and " + age + " years old, and welcome to CAB201");
            Console.Write("Hit any key to exit");
            Console.ReadKey();
        }
    }
}
