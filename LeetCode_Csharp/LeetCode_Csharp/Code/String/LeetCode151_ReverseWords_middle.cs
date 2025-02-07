using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.String
{
    public class LeetCode151_ReverseWords_middle
    {
        #region 方法一：采用双指针去除多余的空格，然后翻转整个字符串，最后翻转每个单词
        //时间复杂度：O(n)
        //空间复杂度：O(n)
        public string ReverseWords(string s)
        {
            int slow = 0;
            char[] sArray = s.ToCharArray();

            // 去除多余的空格
            for (int fast = 0; fast < s.Length; fast++)
            {
                // fast 所指向的不为空格
                if (sArray[fast] != ' ')
                {
                    if (slow != 0) sArray[slow++] = ' ';
                    while (fast < sArray.Length && sArray[fast] != ' ')
                    {
                        sArray[slow++] = sArray[fast++];
                    }
                }
            }

            // 多余的空格去除之后，反转整个字符串
            // 注意：去除多余的空间
            /* Array.Resize()
               时间复杂度：
                1. 如果 n > sArray.Length，Array.Resize 会创建一个新的数组对象，将原数组复制进去，
                因此时间复杂度为 O(n)
                2. 如果 n <= sArray.Length，Array.Resize 会直接截断数组，则时间复杂度为 O(sArray.Length)
            */
            Array.Resize(ref sArray, slow);
            Array.Reverse(sArray);
            // 反转每个单词
            for (int start = 0, j = 0; j <= sArray.Length; j++)
            {
                if (j != sArray.Length && sArray[j] != ' ') continue;
                Array.Reverse(sArray, start, j - start);
                start = j + 1;
            }
            return new string(sArray);
        }
        #endregion 方法一：采用双指针去除多余的空格，然后翻转整个字符串，最后翻转每个单词

        #region 方法二：使用队列处理
        public string ReverseWords2(string s)
        {
            char[] sArray = s.ToCharArray();
            // 存储单词结果
            Stack<string> resStack = new();
            
            StringBuilder sb = new();
            // 去除前后空格，同时将单词取出来
            for(int i = 0; i < sArray.Length; i++)
            {
                if(sArray[i] == ' ') continue;

                while(i < sArray.Length && sArray[i] != ' ')
                {
                    sb.Append(sArray[i++]);
                }
                resStack.Push(sb.ToString());
                sb.Clear();
            }

            while(resStack.Count > 0)
            {
                string str = resStack.Pop();
                sb.Append(str);
                if(resStack.Count > 0) sb.Append(' ');
            }
            return sb.ToString();
        }
        #endregion 方法二：使用队列处理
    }
}
