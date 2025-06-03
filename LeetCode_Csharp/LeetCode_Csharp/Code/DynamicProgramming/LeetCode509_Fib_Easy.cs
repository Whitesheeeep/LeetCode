using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.DynamicProgramming
{
    public class LeetCode509_Fib_Easy
    {
        public int Fib(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            int last = 1, nexttoLast = 0;
            for (int i = 2; i <= n; i++)
            {
                int temp = last + nexttoLast;
                nexttoLast = last;
                last = temp;
            }
            return last;
        }
    }
}