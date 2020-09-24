using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractalJulia
{
    class ComplexNumber
    {
        public double a;//действительная часть
        public double b;//мнимая часть
        public ComplexNumber(double a, double b)
        {
            this.a = a;
            this.b = b;
        }
        public void Square(double cons1, double cons2)
        {
            double result = ((a * a) - (b * b)+cons1) + (2*a*b+cons2);
        }
        public double Magnitude()
        {
            return Math.Sqrt((a * a) + (b * b));
        }
        public void Add(ComplexNumber c)
        {
            a += c.a;
            b += c.b;
        }
    }
}
