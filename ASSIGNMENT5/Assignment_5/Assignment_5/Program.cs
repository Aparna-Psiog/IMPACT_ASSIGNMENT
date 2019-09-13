using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impact_Assignment5
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new int[4];
            var result = 0;
            int n = numbers.Length;
            Console.WriteLine("Enter the array elements:");
            for (var i = 0; i < n; i++)
            {
                numbers[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("The sum of array elements is");
            for (var i = 0; i < n; i++)
            {

                result += numbers[i];

            }
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
