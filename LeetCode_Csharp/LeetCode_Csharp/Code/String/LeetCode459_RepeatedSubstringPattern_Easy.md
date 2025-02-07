# LeetCode459_RepeatedSubstringPattern 重复的子字符串_Easy

**目录：**

- [LeetCode459\_RepeatedSubstringPattern 重复的子字符串\_Easy](#leetcode459_repeatedsubstringpattern-重复的子字符串_easy)
  - [1. 暴力解法](#1-暴力解法)
  - [2. 移动匹配](#2-移动匹配)
  - [3. KMP 算法思想](#3-kmp-算法思想)

## 1. 暴力解法

暴力解法主要要想到：
如果一个长度为 n 的字符串 s 可以由它的一个长度为 n' 的子串 s′ 重复多次构成，那么：

- n 一定是 n' 的倍数
- s' 一定是 s 的前缀
- 对于任意的 i $\in$ [n', n)，有 s[i] = s[i - n']。

尤其是对于第三点，如果是重复子字符串，那么每隔 n' 对应的字符就会重复。

**代码如下：**

```C#
for (int i = 1; i * 2 <= s.Length; i++)
{
    bool match = true;
    if (s.Length % i == 0)
    {
        for (int j = i; j < s.Length; j++)
        {
            if (s[j] != s[j - i])
            {
                match = false;
                break;
            }
        }
    }
    if (match) return true;
}
return false;
```

## 2. 移动匹配

可以将字符串 string s 扩充为 string ss = s+s。

- 如果有重复子字符串，在 ss 中是肯定包含有 s 的，比如 abcabc，扩充后为 abc**abcabc**abc，中间是存在 s: abcabc 的。
- 对于没有重复字符串的，我们可以将 s 分解为 m+n，那么 ss = m+n+m+n，n+m 肯定是与 m + n 不同的，因为 m n 不同不能相互交换。

注意这里在查找的时候要去除两头，不然就没有意义了。

**代码如下：**

```C#
public bool RepeatedSubstringPattern2(string s)
{
    return (s + s).Substring(1, 2 * s.Length - 2).Contains(s);
}
```

## 3. KMP 算法思想

具体看[代码随想录讲解](https://www.bilibili.com/video/BV1cg41127fw/)

**代码如下：**

```C#
public bool RepeatedSubstringPattern3(string s)
{
    // next 数组
    int[] next = new int[s.Length];
    // 初始化
    int prefix_len = 0; next[0] = 0;
    for (int i = 1; i < s.Length; i++)
    {
        if(s[i] == s[prefix_len])
        {
            prefix_len++;
            next[i] = prefix_len;
        }
        else
        {
            if(prefix_len == 0) next[i] = 0;
            else
            {
                prefix_len = next[prefix_len - 1];
                i--;
            }
        }
    }

    return next[s.Length - 1] > 0 && s.Length % (s.Length - next[s.Length - 1]) == 0;
}
```
