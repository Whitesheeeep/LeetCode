# 有效的字母异位词

此题主要是为了培养哈希表处理思维，哈希表一共有三种哈希结构，具体见代码[代码随想录](https://programmercarl.com/%E5%93%88%E5%B8%8C%E8%A1%A8%E7%90%86%E8%AE%BA%E5%9F%BA%E7%A1%80.html#%E5%B8%B8%E8%A7%81%E7%9A%84%E4%B8%89%E7%A7%8D%E5%93%88%E5%B8%8C%E7%BB%93%E6%9E%84)中哈希表理论基础的常见的三种哈希结构：数组、set、map。
此外，为什么采用哈希表？哈希表适用于什么类型题目？适用于给你一个值来判断里面是否有的题目。

此题，先考虑采用哪种哈希结构：
本题主要就是对 26 个字母进行判断，大小要求不高且数字固定，可以直接采用数组的方式进行处理。

``` C#
public bool IsAnagram(string s, string t)
{
            if (s.Length != t.Length)
            {
                return false;
            }
            int[] alphaCount = new int[26];
            for (int i = 0; i < s.Length; i++)
            {
                alphaCount[s[i] - 'a']++;
                alphaCount[t[i] - 'a']--;
            }
            foreach (int count in alphaCount)
            {
                if (count != 0)
                {
                    return false;
                }
            }
            return true;
}
```
