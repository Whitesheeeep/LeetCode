# LeetCode491_FindSubsequences_middle

> [LeetCode491](https://leetcode.cn/problems/non-decreasing-subsequences/description/)

## 易错点

1. **注意题目要求**
题目指明了：至少有两个元素，因此在做题时需要注意，在最初排除极端情况的时候也有考虑：`if(nums.Length < 2) return res;`

2. **不要惯性思维使用 used[i] == used[i-1]**
在做之前的题目的时候，我们采用**数组排序后**再利用 used[i-1] == used[i] && used[i-1] == false 进行树层去重，但是需要注意的是这里要求**进行数组排序**。但是此题目很明显不能进行数组排序。因此不能采用此方法进行树层去重。

## 思路

那么**如何在不能对数组进行排序的情况下进行树层去重**便是本题的主要问题点。那么很容易想到的就是采用散列表对已经遍历过的元素进行记录，然后进行查询对应元素是否存在来判断是否已经遍历过，从而达到去重。那么如何保证其只存在于树层中呢？
其实在经过前面题目的洗礼后，我们可以知道 for 循环本体就是对树层的遍历，i++ 就是移向树层的下一个节点，那么 BackTracking 其实就是对一个树层的处理。我们直接在 backTracking 中声明一个 Hashset(C++ 中的 std::unorderedset)即可保证只在树层中进行去重。而且也不需要在最后对 HashSet 进行回溯，因为最后 HashSet 会随着 BackTracking 的结束而被回收，而不会影响其他层。

## 代码

```C#
public class LeetCode491_FindSubsequences_middle
{
    List<int> path;
    List<IList<int>> res;
    public IList<IList<int>> FindSubsequences(int[] nums)
    {
        path = new List<int>();
        res = new List<IList<int>>();
        if(nums.Length < 2) return res;
        BackTracking(nums, 0);
        return res;
    }

    private void BackTracking(int[] nums, int startIndex)
    {
        // 这就可以在每层进行检测，从而达到树层去重
        HashSet<int> used = new();

        for(int i = startIndex; i < nums.Length; i++)
        {
            // 树层去重
            // 在此处进行去重（或者说是剪枝）的操作的前提是数组进行了排序，但是在此题是不能进行排序的
            // 用字典记录进行去重？
            // 用 HastSet 即可
            if(path.Count > 0 && nums[i] < path.Last() || used.Contains(nums[i])) continue;

            path.Add(nums[i]);
            used.Add(nums[i]);
            if(path.Count > 1) res.Add([..path]);

            BackTracking(nums, i + 1);
            path.RemoveAt(path.Count - 1);

        }
    }
}
```
