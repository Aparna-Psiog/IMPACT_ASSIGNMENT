using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Aparna's Grade book");
            book.AddGrade(87.5);

            var numbers = new int[4];
            var result = 0;
            int n = numbers.Length;

            var grades = new List<double>();
            grades.Add(15.76);
            grades.Add(32.45);
            grades.Add(83.55);
            grades.Add(44.66);
            var result1 = 0.00;
            
            
            foreach(var grade in grades)
            {
                result1 += grade;
            }
            result1/=grades.Count;

            Console.WriteLine($"The average is :{result1:N1}");
            
            //new code for array

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
