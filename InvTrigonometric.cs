using System;

namespace TaylorSeries
{
    public static class InvTrigonometric
    {
        /// <summary>
        /// arcsin(x)를 반환함
        /// </summary>
        /// <param name="x">-1≤x≤1인 실수</param>
        public static double Asin(double x)
        {
            if (x < -1 || x > 1) return Double.NaN;
            double min = -Math.PI * 0.5, max = +Math.PI * 0.5;
            double mid = 0;
            double sin = Trigonometric.Sin(mid);
            while (max - min >= 1.0 / Int32.MaxValue)
            {
                if (sin > x) max = mid;
                else min = mid;
                mid = (max + min) / 2;
                sin = Trigonometric.Sin(mid);
            }
            return mid;
        }

        /// <summary>
        /// arccos(x)를 반환함
        /// </summary>
        /// <param name="x">-1≤x≤1인 실수</param>     
        
        public static double Acos(double x)
        {
            if (x < -1 || x > 1) return Double.NaN;
            double min = 0, max = Math.PI;
            double mid = Math.PI / 2;
            double cos = Trigonometric.Cos(mid);
            while (max - min >= 1.0 / Int32.MaxValue)
            {
                if (cos < x) max = mid;
                else         min = mid;
                mid = (max + min) / 2;
                cos = Trigonometric.Cos(mid);
            }
            return mid;
        }

        /// <summary>
        /// arctan(x)를 반환함
        /// </summary>
        
        public static double Atan(double x)
        {
            if (Double.IsPositiveInfinity(x)) return +Math.PI * 0.5;
            if (Double.IsNegativeInfinity(x)) return -Math.PI * 0.5;
            double min = -Math.PI * 0.5, max = +Math.PI * 0.5;
            double mid = 0;
            double tan = Trigonometric.Tan(mid);
            while (max - min >= 1.0 / Int32.MaxValue)
            {
                if (tan > x) max = mid;
                else         min = mid;
                mid = (max + min) / 2;
                tan = Trigonometric.Tan(mid);
            }
            return mid;
        }

        public static double Acot(double x) => Atan(1 / x);

        public static double Asec(double x) => Acos(1 / x);

        public static double Acsc(double x) => Asin(1 / x);
    }
}
