# LeetCode46 字母异位词分组_middle

主要思路 [LeetCode 题解](https://leetcode.cn/problems/group-anagrams/solutions/)讲得很清楚了：

做这种查的题目，第一得想到哈希表，第二就是想该使用那种哈希表结构：数组、set 还是 Map？此题很明显采用数组和 set 不太合适，所以最好是采用 Map，那么 Map 的 key 该采用什么呢？这就决定了本题目的两种方法。

1. 方法 1：就是排序+哈希表
2. 方法 2：就是计数+哈希表
方法2 相较于方法 1 更好原因在于它省去了排序的过程，直接用数词重组的方式规避了排序。
