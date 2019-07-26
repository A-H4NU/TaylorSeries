using System;

namespace TaylorSeries
{
    public static class Trigonometric
    {
        private static double[] S = new double[100];

        public static void Initialize()
        {
            S[0] = 1;
            for (int i = 1; i < S.Length; ++i)
                S[i] = S[i - 1] / i;
        }

        private static double DivRem(double x, double div)
        {
            if (div == 0) return Double.NaN;
            if (x >= 0) while (x >= 0) x -= div;
            else while (x < -div) x += div;
            return x + div;
        }

        public static double Sin(double x)
        {
            x = DivRem(x, 2 * Math.PI);
            if (x >= Math.PI * 0.5 && x < Math.PI * 1.5) x = Math.PI - x;
            else if (x >= Math.PI * 1.5 && x < Math.PI * 2) x -= Math.PI * 2;
            return T2(x);
        }

        public static double Cos(double x) => Sin(x + Math.PI * 0.5);

        public static double Tan(double x) => Sin(x) / Cos(x);

        public static double Sec(double x) => 1 / Cos(x);

        public static double Csc(double x) => 1 / Sin(x);

        public static double Cot(double x) => 1 / Tan(x);

        public static double SlowSin(double x)
        {
            x = DivRem(x, 2 * Math.PI);
            if (x >= Math.PI * 0.5 && x < Math.PI * 1.5) x = Math.PI - x;
            else if (x >= Math.PI * 1.5 && x < Math.PI * 2) x -= Math.PI * 2;
            double d1 = D(x, -Math.PI * 0.5), d2 = D(x, 0), d3 = D(x, +Math.PI * 0.5);
            double t1 = T1(x), t2 = T2(x), t3 = T3(x);
            return d1 * t1 + d2 * t2 + d3 * t3;
        }

        private static double T1(double x)
        {
            double res = 0;
            double r = (x + Math.PI * 0.5) * (x + Math.PI * 0.5);
            double cur = 1;
            for (int i = 0; i < S.Length; i += 2)
            {
                if (i != 0) cur *= r;
                res += (i % 4 == 0 ? -1 : 1) * cur * S[i];
            }
            return res;
        }

        private static double T2(double x)
        {
            double res = 0;
            double r = x * x;
            double cur = x;
            for (int i = 1; i < S.Length; i += 2)
            {
                if (i != 1) cur *= r;
                res += ((i - 1) % 4 == 0 ? 1 : -1) * cur * S[i];
            }
            return res;
        }

        private static double T3(double x)
        {
            double res = 0;
            double r = (x - Math.PI * 0.5) * (x - Math.PI * 0.5);
            double cur = 1;
            for (int i = 0; i < S.Length; i += 2)
            {
                if (i != 0) cur *= r;
                res += (i % 4 == 0 ? 1 : -1) * cur * S[i];
            }
            return res;
        }

        private static double D(double x, double p)
        {
            if (Math.Abs(x - p) >= Math.PI / 2) return 0;
            return 1 - (2 / Math.PI) * Math.Abs(x - p);
        }
    }
}
