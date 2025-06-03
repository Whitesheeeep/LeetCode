namespace LeetCode_Csharp.Code.DynamicProgramming
{
    public class LeetCode70_ClimbStairs_Easy
    {
        public int ClimbStairs(int n)
        {
            if (n == 1) return 1;
            int nexttoLast = 1, last = 2;
            for (int i = 0; i < n - 2; i++)
            {
                int temp = last + nexttoLast;
                nexttoLast = last;
                last = temp;
            }
            return last;
        }
    }
}
