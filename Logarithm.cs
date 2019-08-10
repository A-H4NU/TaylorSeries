using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaylorSeries
{
    public static class Logarithm
    {
        public const double LnMaxValue = +709.78271289338;
        public const double LnMinValue = -744.44007192138;

        /// <summary>
        /// ln(x)를 반환함
        /// </summary>
        /// <param name="x">x>0인 실수</param>
        public static double Log(double x)
        {
            if (x <= 0) return Double.NaN;
            else if (x == 0) return Double.NegativeInfinity;
            else if (x == 1) return 0;
            else if (Double.IsPositiveInfinity(x)) return x;
            double min = LnMinValue, max = LnMaxValue;
            double mid = (min + max) / 2;
            double exp = Exponential.Exp(mid);
            while (Math.Abs(exp - x) >= 1.0 / Int32.MaxValue)
            {
                if (exp > x) max = mid;
                else         min = mid;
                mid = (min + max) / 2;
                exp = Exponential.Exp(mid);
            }
            return mid;
        }

        /// <summary>
        /// log_b(x)를 반환함
        /// </summary>
        /// <param name="b">b>0, b≠인 실수</param>
        /// <param name="x">x>0인 실수</param>
        public static double Log(double b, double x) => Log(x) / Log(b);
    }
}
