using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.StackAndQueue
{
    /* 这道题主要是思考的是否全面，
     * 1. 首先要考虑到字符串为空的情况
     * 2. 成功情况：遍历完字符串后，栈应该为空。
     * 3. 失败情况：1.栈为空，但是还有右括号 : } 2.栈不为空，但是没有匹配的括号
     * 4. 第二种失败情况又有两种情况：1. {] 2. [}
     */
    public class LeetCode20_ValidBraket_Easy
    {
        public bool IsValid(string s)
        {
            if(s == null) return false;
            Stack<char> charStack= new Stack<char>();
            bool result = false;

            foreach(char c in s)
            {
                if(c == '(' || c == '[' || c == '{')
                {
                    charStack.Push(c);
                
                }
                else
                {
                    if(charStack.Count == 0) return false;
                    char temp = charStack.Pop();
                    result = temp switch
                    {
                        '(' => c == ')',
                        '[' => c == ']',
                        '{' => c == '}',
                        _ => false
                    };
                    if(!result) return false;
                }
            }
            // if(charStack.Count == 0) return true;
            // return false;
            return charStack.Count == 0;
        }

        //优化代码
        public bool IsValid2(string s)
        {
            Stack<char> charsStack= new Stack<char>();
            Dictionary<char, char> dic = new Dictionary<char, char>()
            {
                {')', '('},
                {']', '['},
                {'}', '{'}
            };

            foreach(char c in s)
            {
                if(dic.ContainsKey(c))
                {
                    if(charsStack.Count == 0 || charsStack.Pop() != dic[c]) return false;
                }
                else
                {
                    charsStack.Push(c);
                }
            }

            return charsStack.Count == 0;
        }
    }
}
