namespace LeetCode_Csharp
{
    public partial class Solution
    {
        //Solution 1: Binary Search
        public bool IsPerfectSquqre(int num)
        {
            int left = 0;
            int right = Math.Min(num, 46340);
            int mid = 0;
            while (left <= right)
            {
                mid = left + (right - left) / 2;
                if (mid * mid == num) return true;
                else if (mid * mid < num) left = mid + 1;
                else right = mid - 1;
            }
            return false;
        }

        //Solution 2: Newton Iteration
        public bool IsPerfectSquqre_2(int num)
        {
            
            return NewTonIteration(num, num);
        }

        public bool NewTonIteration(int num, in int target)
        {
            int iterNum = (num + target / num) / 2;
            if(iterNum * iterNum == target) return true;
            else if(iterNum >= num) return false;
            else return NewTonIteration(iterNum, target);
        }

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