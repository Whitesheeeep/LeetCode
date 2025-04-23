using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.GreedyAlgorithm
{
    public class LeetCode376_WiggleMaxLength_middle
    {
        public int WiggleMaxLength(int[] nums)
        {
            // 预处理
            int[] subNums = new int[nums.Length - 1];
            for (int i = 1; i < nums.Length; i++)
            {
                subNums[i - 1] = nums[i] - nums[i - 1];
            }

            int count = 1;
            int temp = 0;
            for (int i = 0; i < subNums.Length; i++)
            {
                if (subNums[i] == 0) continue;
                else
                {
                    // 初次遇到时
                    if(temp == 0) 
                    {
                        temp = subNums[i] > 0? 1 : -1;
                        count++;
                        continue;
                    }
                    
                    if(temp * subNums[i] < 0)
                    {
                        count ++;
                        temp = -temp;
                    }
                }
            }
            return count;
        }

        // 下面这个是求连续的，不是子序列
        public int WiggleMaxLengthButContinous(int[] nums)
        {
            if (nums.Length == 1) return 1;
            if (nums.Length == 2 && nums[0] != nums[1]) return 2;
            else if (nums.Length == 2) return 1;

            int res = 0, count = 1;
            int slow = 0, fast = 1;

            for (; fast < nums.Length; fast++)
            {
                int slowNum = nums[slow], fastNum = nums[fast];
                if (slowNum == fastNum)
                {
                    slow++;
                    continue;
                }
                // slowNum != fastNum
                else
                {
                    bool temp = fastNum - slowNum > 0;
                    count = 2;
                    fast++;
                    for (; fast < nums.Length; fast++)
                    {
                        bool _temp = nums[fast] - nums[fast - 1] > 0;
                        if (nums[fast] == nums[fast - 1])
                        {
                            count = fast - slow;
                            res = count > res ? count : res;
                            slow = fast;
                            break;
                        }
                        // 不相等
                        else if (_temp == temp)
                        {
                            res = fast - slow > res ? fast - slow : res;
                            slow = fast - 1;
                            temp = nums[fast] - nums[fast - 1] > 0;
                            count = 2;
                            continue;
                        }
                        else
                        {
                            temp = _temp;
                            count++;
                        }
                    }
                }
            }

            return count > res ? count : res;
        }
    }
}
