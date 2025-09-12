using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.DoublePointer
{
    public class 翻转字符串里的单词
    {
        public static void Method()
        {
            string s = Console.ReadLine();
            // Console.WriteLine(string.Join(" ", s.Split(' ', StringSplitOptions.RemoveEmptyEntries).Reverse()));
            // 消除前后的空格
            int left = 0, right = s.Length - 1;
            while (left <= right && s[left] == ' ') left++;
            while (left <= right && s[right] == ' ') right--;
            if (left > right)
            {
                Console.WriteLine("");
                return;
            }
            string ss = s[left..(right + 1)];
            // 去掉中间的空格
            int slow = 0, fast = 0;
            char[] chars = ss.ToCharArray();
            while (fast < chars.Length)
            {
                if (chars[fast] != ' ')
                {
                    if (slow != 0) chars[slow++] = ' ';
                    while (fast < chars.Length && chars[fast] != ' ')
                    {
                        chars[slow++] = chars[fast++];
                    }
                }
                fast++;
            }
        }
    }
}
