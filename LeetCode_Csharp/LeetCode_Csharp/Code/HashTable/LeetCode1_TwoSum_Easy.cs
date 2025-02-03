using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.HashTable
{
    public class LeetCode1_TwoSum_Easy
    {
        //时间复杂度：O(n)
        public int[] TwoSum(int[] nums, int target)
        {
            int[] res = new int[2];
            Dictionary<int, int> dict = new();
            foreach(int num in nums)
            {
                if(dict.ContainsKey(num))
                    dict[num]++;
                else
                    dict[num] = 1;
            }

            for(int i = 0; i < nums.Length; i++)
            {
                int diff = target - nums[i];
                if(dict.TryGetValue(diff, out int count))
                {
                    //count > 1 说明有重复的数字，找到第二个数字的下标；
                    //count == 1 说明只有一个数字，找到第二个数字的下标；
                    if(count > 1 || (count == 1 && diff != nums[i]))
                    {
                        res[0] = i;
                        for(int j = i + 1; j < nums.Length; j++)
                        {
                            if(nums[j] == diff)
                            {
                                res[1] = j;
                                break;
                            }
                        }
                        break;
                    }
                }
            }
            return res;
        }

        //优化
        //时间复杂度：O(n)
        //空间复杂度：O(n)
        //dict 第二个参数存储下标，这样就没必要再去遍历数组去找下标了
        public int[] TwoSum2(int[] nums, int target)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for(int i = 0; i < nums.Length; i++)
            {
                if(dict.ContainsKey(target - nums[i])) return [dict[target-nums[i]], i];
                else if(!dict.ContainsKey(nums[i])) dict.Add(nums[i], i);
            }
            return [];
        }
    }
}
