using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
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
    
        //牛顿迭代法
        //原理：https://www.bilibili.com/video/BV1qM4y1B7Kr?spm_id_from=333.788.recommend_more_video.4&vd_source=f2e80a31de0479ff169b9ddd0c34f7f8
        //前提：取点要注意：https://blog.csdn.net/pipisorry/article/details/24574293（看不成功反例）
        //x = x-y/(2*x)# 不断用(x,f(x)) 的切线来逼近方程 x 2 −a=0 的根 (斜率不是2 为2x
        //数学推导:那么，x−f(x)/(2x) 就是一个比 x更接近的近似值。代入 f(x)=x2−a 得到 x−(x2−a)/(2x)，也就是 (x+a/x)/2
        public int MySqrt_2(int x)
        {
            if (x == 0) return 0;
            return (int)sqrts(x, x);
            
            
        }

        public double sqrts(double x, in double y)
        {
            double res = (x + y/x) / 2;
            //res 和 x 分别是迭代前后的值
            //因为迭代到最后，res 和 x 会非常接近，已经超过 double 的精度了，所以这里直接返回 x
            if(res >= x) return x;
            else return sqrts(res, y);
        }
    }
}