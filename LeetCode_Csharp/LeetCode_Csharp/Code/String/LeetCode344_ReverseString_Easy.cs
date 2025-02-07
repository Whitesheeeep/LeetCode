using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.String
{
    public class LeetCode344_ReverseString_Easy
    {
        public void ReversString(char[] s)
        {
            int left  = 0;
            int right = s.Length - 1;
            // 这里要注意一下是 <，而不是 != ，因为如果是 != 的话，
            // 字符串为奇数的时候，left 和 right 可能会错过, 导致 index out of range
            while(left < right)
            {
                // swap
                char temp = s[left];
                s[left] = s[right];
                s[right] = temp;
                left++;
                right--;
            }
        }
    }
}
