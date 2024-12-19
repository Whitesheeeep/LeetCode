using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace LeetCode_Csharp
{
    public class LeetCode69
    {
        /*
        https://leetcode.cn/problems/sqrtx/description/
        给你一个非负整数 x ，计算并返回 x 的 算术平方根 。

        由于返回类型是整数，结果只保留 整数部分 ，小数部分将被 舍去 。

        注意：不允许使用任何内置指数函数和算符，例如 pow(x, 0.5) 或者 x ** 0.5 。
        */
        public int MySqrt(int x)
        {
            int left = 0;
            int right = Math.Min(x,46340);
            int mid = 0;
            Debug.WriteLine(int.MaxValue);
            while (left <= right)
            {
                //考虑溢出
                mid = left + (right - left) / 2;
                //考虑溢出，这里 mid*mid 如果 mid 过大会溢出
                if (mid * mid == x) return mid;
                else if (mid * mid < x) left = mid + 1;
                else right = mid - 1;
                
            }
            return left - 1;
        }
    }
}