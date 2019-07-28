using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaylorSeries
{
    public class Exponential
    {
        /// <summary>
        /// x^n을 반환함
        /// </summary>
        /// <returns></returns>
        private static double IntPow(double x, int n)
        {
            if (n < 0) return 1 / IntPow(x, -n);
            double res = 1;
            for (int i = 0; i < n; ++i)
                res *= x;
            return res;
        }

        /// <summary>
        /// <see cref="Math.E"/>^x를 반환함
        /// </summary>
        /// <returns></returns>
        public static double Exp(double x)
        {
            if (x == 0) return 1;
            if (x == 1) return Math.E;
            double res = 1;
            int a = (int)Math.Round(x);
            double p = 1;
            double r = x - a;
            for (int n = 1; n <= Factorial.Expanded; ++n)
            {
                p *= r;
                res += p * Factorial.Get(n);
            }
            return IntPow(Math.E, a) * res;
        }

        /// <summary>
        /// b^x를 반환함
        /// </summary>
        /// <param name="b">b ≥ 0인 배정밀도 부동 소수점 숫자</param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double Power(double b, double x)
        {
            if (b == 1 || x == 0) return 1;
            if (b < 0) return Double.NaN;
            if (x == 1) return b;
            double res = 1;
            int a = (int)Math.Round(x);
            double p = 1;
            double r = (x - a) * Logarithm.Log(b);
            for (int n = 1; n <= Factorial.Expanded; ++n)
            {
                p *= r;
                res += p * Factorial.Get(n);
            }
            return IntPow(b, a) * res;
        }
    }
}
