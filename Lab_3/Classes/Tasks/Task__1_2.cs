using System;
using Lab_3.Classes.Models;
using static Lab_3.Classes.Models.MyFrac;

namespace Lab_3.Classes.Tasks
{
    public class Task__1_2 : IRunnable
    {
        public void Run()
        {
            MyFrac fraction1 = Fraction(5, 4);
            MyFrac fraction2 = Fraction(-1, 2);
            MyFrac fraction3 = Fraction(-5);

            Console.WriteLine("Expected for double conversion: 1.25");
            Console.WriteLine("Actual: " + (double) fraction1);
            
            Console.WriteLine("\nExpected for string representation: 5/4");
            Console.WriteLine("Actual: " + fraction1);
            
            Console.WriteLine("\nExpected for string with Integer part representation: (1+1/4)");
            Console.WriteLine("Actual: " + fraction1.ToStringWithIntegerPart());
            Console.WriteLine("\nExpected for string with Integer part representation: -5");
            Console.WriteLine("Actual: " + fraction3.ToStringWithIntegerPart());
            
            Console.WriteLine("\nExpected for negation: -5/4");
            Console.WriteLine("Actual: " + -fraction1);
            Console.WriteLine("\nExpected for addition: 3/4");
            Console.WriteLine("Actual: " + (fraction1 + fraction2));
            Console.WriteLine("\nExpected for subtraction: 7/4");
            Console.WriteLine("Actual: " + (fraction1 - fraction2));
            Console.WriteLine("\nExpected for multiplication: -5/8");
            Console.WriteLine("Actual: " + fraction1 * fraction2);
            Console.WriteLine("\nExpected for division: -5/2");
            Console.WriteLine("Actual: " + fraction1 / fraction2);

            Console.WriteLine("\nExpected for Sum1: 10/11");
            Console.WriteLine("Actual: " + CalcSum1(10));
            Console.WriteLine("\nExpected for Sum2: 11/20");
            Console.WriteLine("Actual: " + CalcSum2(10));
        }

        private static MyFrac CalcSum1(int n)
        {
            MyFrac sum = Fraction(0);

            for (int i = 1; i <= n; ++i)
                sum += Fraction(1, i * (i + 1));

            return sum;
        }

        private static MyFrac CalcSum2(int n)
        {
            MyFrac product = Fraction(1);

            for (int i = 2; i <= n; ++i)
                product *= Fraction(1) - Fraction(1, (long) Math.Pow(i, 2));

            return product;
        }
    }
}