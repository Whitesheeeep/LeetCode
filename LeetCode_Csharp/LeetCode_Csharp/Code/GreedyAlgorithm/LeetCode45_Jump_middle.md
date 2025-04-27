# LeetCode45_Jump_middle

- [LeetCode45\_Jump\_middle](#leetcode45_jump_middle)
  - [思路](#思路)

> [LeetCode45 跳跃游戏II](https://leetcode.cn/problems/jump-game-ii/description/)

## 思路

本题目延续跳跃游戏的思路，但是相较于跳跃游戏还是有很大的不同的，难度也相较提升了很多。
跳跃游戏只用管能不能达到，而这里主要找到最小步数。
那么要找到最小步数，也就是每一步最好跳到最优的地方，也是延续跳跃游戏的思路：**利用范围进行判断**。
跳跃游戏1（以下简称J1）是找范围的最大，然后利用这个最大更新范围来判断最后能否跳到nums 尾巴，顺着这个思路，其实我们能发现，每一次进行范围查找就是跳一步。因为，最佳位置能跳跃到 i 到 nums[i] + i，最佳位置后面的位置跳跃的位置范围一定 <= (i 到 nums[i])，那么跳到最佳位置即可，因此每次范围查找就是跳跃一步，逻辑上同时查找下一个最大范围。而且工程上可以直接顺着 范围 的最大位置往后查找，没必要从最佳位置重新往后搜，因为在上一个范围搜索中已经证明这部分内容不如最佳位置，所以也就可以直接丢弃判断。直接从上一个范围的下一个位置进行，因此可以使用一个 for 循环就能解决。

## 代码思路

整理思路：

1. 使用 for 循环遍历数组
2. 每次刷新最大距离
3. 通过暂存每次的最大距离，配合 if 进行判断是否超过达到最大距离，根据上述可以知道就是跳一步的时候，此时就可以对步数加一，并且刷新最大距离
但是对于第三步，可能存在一中特殊情况，对于最后如果最大距离超过 nums.Length ，那么可能就会少跳一步（因为是通过 i == 最大距离判断的），那么可以在最后如果 i == nums.Length 也算入一步。
4. 极限考虑：只有 1 个数字，就传 0，在开始的时候就处理；当第一个数直接达到或者超过最大的时候如何处理？根据上述思路会直接遍历到最后一位然后 ++，得到最后结果为 1。

```C#
public int Jump(int[] nums)
{
    if (nums.Length == 1) return 0;
    int count = 0;
    // 初始化
    int cover = nums[0];
    int temp = cover;// 指向能移动到的最大位置
    for (int i = 1; i < nums.Length; i++)
    {
        // 处理逻辑
        if(nums[i] + i > temp)
        {
            temp = nums[i] + i;
        }
        if(i >= cover || i == nums.Length - 1) // 跳
        {
            cover = temp;
            count++;
        }
    }
    return count;
}

public class Solution
{
    public int Jump(int[] nums)
    {
        int cur = 0, next = 0, step = 0;
        for (int i = 0; i < nums.Length - 1; i++)
        {
            next = Math.Max(next, i + nums[i]);
            if (i == cur)
            {
                cur = next;
                step++;
                if(next >= nums.Length - 1) break;
            }
        }
        return step;
    }
}
```
