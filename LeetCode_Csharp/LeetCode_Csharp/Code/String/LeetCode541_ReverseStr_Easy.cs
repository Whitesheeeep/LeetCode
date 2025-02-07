using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.String
{
    public class LeetCode541_ReverseStr_Easy
    {
        // 本体主要需要记录的是处理“每2k个字符的前k个字符”这个过程
        // 实际上不用计数器进行计数，只需要跳过不需要处理的部分即可
        // 也就是我们可以把指针 i 每次都移动 2k 个位置，但是只处理前 k 个字符
        // 这样就能实现每 2k 个字符的前 k 个字符进行反转而不需要计数器
        public string ReverseStr(string s, int k)
        {
            char[] sArray = s.ToCharArray();
            for (int i = 0; i < s.Length; i += 2 * k)
            {
                int left = i, right = i + k  <= s.Length ? i + k - 1 : s.Length - 1;
                while (left < right)
                {
                    char temp = sArray[left];
                    sArray[left] = sArray[right];
                    sArray[right] = temp;
                    left++;
                    right--;
                }
            }
            return new string(sArray);

        }
    }
}
