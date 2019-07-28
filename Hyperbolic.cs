using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaylorSeries
{
    public static class Hyperbolic
    {
        public static double Sinh(double x)
        {
            double exp = Exponential.Exp(x);
            return (exp - 1 / exp) / 2;
        }

        public static double Cosh(double x)
        {
            double exp = Exponential.Exp(x);
            return (exp + 1 / exp) / 2;
        }

        public static double Tanh(double x)
        {
            double e2xp = Exponential.Exp(2 * x);
            return (e2xp - 1) / (e2xp + 1);
        }

        public static double Csch(double x) => 1 / Sinh(x);

        public static double Sech(double x) => 1 / Cosh(x);

        public static double Coth(double x) => 1 / Tanh(x);
    }
}
