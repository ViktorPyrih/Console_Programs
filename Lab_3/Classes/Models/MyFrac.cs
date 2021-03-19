using System;

namespace Lab_3.Classes.Models
{
    internal struct MyFrac
    {
        private long Numerator { get; set;  }

        private long Denominator { get; set; }

        public static MyFrac Fraction(long numerator, long denominator = 1) 
            => new MyFrac(numerator, denominator);
        
        private MyFrac(long numerator, long denominator)
        {
            if (denominator == 0)
                throw new ArgumentException("Denominator cannot be zero.", nameof(denominator));
            Numerator = numerator;
            Denominator = denominator;
            Simplify();
        }
        
        private void Simplify()
        {
            if (Denominator < 0)
            {
                Numerator = -Numerator;
                Denominator = -Denominator;
            }

            long gcd = Gcd(Numerator, Denominator);
            Numerator /= gcd;
            Denominator /= gcd;
        }
        
        private long Gcd(long numerator, long denominator)
        {
            numerator = Math.Abs(numerator);
            denominator = Math.Abs(denominator);
            
            while(true)
            {
                var remainder = numerator % denominator;
                if (remainder == 0) return denominator;
                numerator = denominator;
                denominator = remainder;
            }
        }

        public string ToStringWithIntegerPart()
        {
            if (Denominator == 1) return Numerator.ToString();
            string sign = Numerator >= 0 ? "" : "-";
            return $"{sign}"
                   + $"({Math.Abs(Numerator) / Denominator}+"
                   + $"{Numerator % Denominator}/{Denominator})";
        }

        public override string ToString()
            => $"{Numerator}/{Denominator}";

        public static explicit operator double(MyFrac a) 
            => (double) a.Numerator / a.Denominator;
        
        public static MyFrac operator +(MyFrac a) => a;
        
        public static MyFrac operator -(MyFrac a) 
            => new MyFrac(-a.Numerator, a.Denominator);

        public static MyFrac operator +(MyFrac a, MyFrac b) 
            => new MyFrac(
                a.Numerator * b.Denominator + b.Numerator * a.Denominator,
                a.Denominator * b.Denominator
            );

        public static MyFrac operator -(MyFrac a, MyFrac b)
            => a + -b;

        public static MyFrac operator *(MyFrac a, MyFrac b)
            => new MyFrac(a.Numerator * b.Numerator, a.Denominator * b.Denominator);

        public static MyFrac operator /(MyFrac a, MyFrac b)
        {
            if (b.Numerator == 0)
                throw new DivideByZeroException();
            return new MyFrac(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
        }
    }
}