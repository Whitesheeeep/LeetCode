using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp
{
    public class LeetCode26
    {
        public int RemoveDuplicates(int[] nums)
        {
            //记录唯一元素的个数
            int k = 1;
            int slow = 0;
            for(int fast = 1; fast < nums.Length; fast ++)
            {
                if(nums[fast] != nums[slow])
                {
                    nums[++slow] = nums[fast];
                    k++;
                }
                
            }
            return k;
        }
    }
}