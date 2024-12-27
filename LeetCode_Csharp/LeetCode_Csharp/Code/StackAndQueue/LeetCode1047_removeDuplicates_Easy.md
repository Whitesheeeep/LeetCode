# LeetCode1047_removeDuplicates_Easy

这道题思路很简单，就是每次查询的时候，看一下 Stack 里面是否是一样的，是一样的就消去，不是一样的就保存，最后输出的时候注意一下倒着填入 string 就行了。

唯一需要补充的就是各种不同的反转字符串的方法以及时间复杂度。采用 char[] 来装最后的结果，可以直接通过从后面填入字符的方式规避反转字符，但是仍然需要一个 new string(char[]) 的过程，这个过程的时间复杂度为 O(n)。如果不规避的话，char[] 数组自身有一个 Reverse() 方法支持翻转，但是返回的是 IEnumerable\<char\> ，需要经过一个 ToArray() 转换成 char[] 再转成 String。总共是 O(3n)。

当然如果采用 StringBuilder 来装最后结果的字符串，要使用到 Insert(0,char) ，Insert 时间复杂度为 O(n)，（n 为要插入点字符数量），与上述一样。
