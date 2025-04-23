# LeetCode55_CanJump_middle

> [LeetCode55 跳跃游戏](https://leetcode.cn/problems/jump-game/description/)

## 思路

如我自己的答题思路差不多，但是不用再重复搜索，此处时间复杂度为 O(n)，我们确实只用看是否能够超过或达到 nums.Length - 1，也就是看**跳跃的范围能否达到 nums.Length - 1**，但是如下图所示，因为跳跃范围是动态的，那么如何实现这个动态的范围呢？这就考验我们的工程能力了，因此这道题也可以是算是增加我们工程能力的题目。

