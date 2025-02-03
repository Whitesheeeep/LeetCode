using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.HashTable
{
    public class LeetCode454_FourSumCount_middle
    {
        //时间复杂度：O(n^2)
        public int FourSumCount(int[] nums1, int[] nums2, int[] nums3, int[] nums4) 
        {
            int res = 0;
            //key: nums1[i] + nums2[j]  value: 出现的次数
            Dictionary<int, int> dict = new();
            foreach(int num1 in nums1)
            {
                foreach(int num2 in nums2)
                {
                    dict[num1 + num2] = dict.GetValueOrDefault(num1 + num2, 0) + 1;
                }
            }

            foreach(int num3 in nums3)
            {
                foreach(int num4 in nums4)
                {
                    if(dict.ContainsKey(-num3-num4)) res += dict[-num3-num4];
                }
            }
            return res;
        }
    }
}
