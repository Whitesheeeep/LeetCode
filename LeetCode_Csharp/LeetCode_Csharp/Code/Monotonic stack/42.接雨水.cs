/*
 * @lc app=leetcode.cn id=42 lang=csharp
 *
 * [42] 接雨水
 */

// @lc code=start
using Index = int;
public partial class Solution
{
    public int Trap(int[] height)
    {
        int res = 0;

        Stack<Index> monoStack = new();
        monoStack.Push(0);


        for (int i = 1; i < height.Length; i++)
        {
            if (height[i] <= height[monoStack.Peek()])
            {
                monoStack.Push(i);
            }
            else
            {
                while (monoStack.Count() > 0 && height[i] > height[monoStack.Peek()])
                {
                    int index = monoStack.Pop();
                    if (monoStack.Count() > 0)
                    {
                        int h = Math.Min(height[monoStack.Peek()], height[i]) - height[index];
                        int w = i - monoStack.Peek() - 1;
                        res += h * w;
                    }

                }
                monoStack.Push(i);
            }
        }
        return res;
    }

    /* public int Trap(int[] height)
    {
        int[] resIndex = new int[height.Length];
        for (int i = 0; i < resIndex.Length; i++) resIndex[i] = -1;

        Stack<Index> monoStack = new();

        for (int i = 1; i < height.Length; i++)
        {
            while (monoStack.Count() > 0 && height[i] >= height[monoStack.Peek()])
            {
                int index = monoStack.Pop();
                resIndex[index] = i;
            }
            monoStack.Push(i);
        }

        int waterCapacity = 0;
        for (int i = 0; i < resIndex.Length; i++)
        {
            if (resIndex[i] > i && height[i] > 0)
            {
                waterCapacity += CountWaterCapacity(i, resIndex[i], height);
                i = resIndex[i];
            }
        }
        return waterCapacity;
    }

    private int CountWaterCapacity(int i, int v,in int[] height)
    {
        if (i + 1 >= v) return 0;

        int len = v - i - 1, h = Math.Min(height[i], height[v]);
        return len * h - height[(i + 1)..v].Sum();
    } */
}
// @lc code=end

