using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaylorSeries
{
    public static class Factorial
    {
        private static double[] _s = new double[] { 1 };

        public static void Expand(int n)
        {
            int lastL = _s.Length;
            if (lastL > n) return;
            double[] newS = new double[n + 1];
            Array.Copy(_s, 0, newS, 0, lastL);
            for (int i = lastL; i <= n; ++i)
                newS[i] = newS[i - 1] / i;
            _s = newS;
        }

        public static double Get(int n) => _s[n];

        public static int Expanded => _s.Length - 1;
    }
}
