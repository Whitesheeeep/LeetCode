using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.StackAndQueue
{
    public class LeetCode1047_removeDuplicates_Easy
    {
        public string RemoveDuplicates(string s) 
        {
            Stack<char> stack = new Stack<char>();
            char[] chars;
            foreach (char c in s)
            {
                if(stack.Count == 0) stack.Push(c);
                else
                {
                    if(stack.Peek() == c) stack.Pop();
                    else stack.Push(c);
                }
            }
            chars = new char[stack.Count];
            
            while(stack.Count > 0)
            {
                chars[stack.Count - 1] = stack.Pop();
            }
            return new string(chars);
        }
    }
}
