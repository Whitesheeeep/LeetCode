using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.GreedyAlgorithm
{

    public class LeetCode55_CanJump_middle
    {
        // 时空复杂度都高了，没有必要每次都搜索查看 nums[index + i]，这样
        // 会重复搜索，导致时间复杂度升高，而是用 flags 标记来减少复杂度，
        // 则会增加空间复杂度。
        // 时间复杂度可以缩减到 O(n)，空间复杂度缩减到 O(1)，思路见解析。 
        bool[] flags;
        // 贪心：跳到最远的地方，index + nums[index]
        public bool CanJump(int[] nums)
        {
            flags = new bool[nums.Length];
            return BackTracking(nums, 0);

        }

        private bool BackTracking(int[] nums, int index)
        {
            if (index + 1 >= nums.Length) return true;

            for (int i = nums[index]; i > 0; i--)
            {
                if (index + i < nums.Length && flags[index + i] == true) continue; // 剪枝
                if (BackTracking(nums, index + i)) return true;
                flags[index + i] = true; // 默认为 false ，所以使用 true 来标记过不了的
            }
            return false;
        }
    }
}
