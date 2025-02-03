using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.HashTable
{
    public class LeetCode202_IsHappy_Easy
    {
        #region 方法一：哈希表判断循环
        //时间复杂度：O(logN)
        public bool IsHappy(int n)
        {
            //注意 特殊情况：1
            HashSet<int> set = [];
            int res = 0;
            while(res != 1)
            {
                res = 0;
                while(n != 0)
                {
                    res += n % 10 * (n % 10);
                    n /= 10;
                }
                if(set.Contains(res))
                {
                    return false;
                }
                set.Add(res);
                n = res;
            }
            return true;
        }
        #endregion 方法一：哈希表判断循环

        #region 方法二：快慢指针
        //时间复杂度：O(logN)
        public bool IsHappy2(int n)
        {
            int slow = n, fast = n;
            do
            {
                slow = GetNext(slow);
                fast = GetNext(GetNext(fast));
            } while (slow != fast);
            return slow == 1;
        }

        public int GetNext(int n)
        {
            int res = 0;
            while (n != 0)
            {
                res += n % 10 * (n % 10);
                n /= 10;
            }
            return res;
        }
        #endregion 方法二：快慢指针

    }
}
