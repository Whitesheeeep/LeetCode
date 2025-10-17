/*
 * @lc app=leetcode.cn id=739 lang=csharp
 *
 * [739] 每日温度
 */

// @lc code=start
public partial class Solution {
    public static int[] DailyTemperatures(int[] temperatures) {
        int[] res = new int[temperatures.Length];

        // 单调栈
        Stack<int> indexStack = new();
        indexStack.Push(0);

        for (int i = 1; i < temperatures.Length; i++)
        {
            int temp = temperatures[i];
            
            while (indexStack.Count > 0 && temp > temperatures[indexStack.Peek()])
            {
                var index = indexStack.Pop();
                res[index] = i - index;
            }
            indexStack.Push(i);
        }

        return res;
    }
}
// @lc code=end

