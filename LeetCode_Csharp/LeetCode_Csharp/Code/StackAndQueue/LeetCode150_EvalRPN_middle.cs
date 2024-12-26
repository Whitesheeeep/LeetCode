using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.StackAndQueue
{
    public class LeetCode150_EvalRPN_middle
    {
        public int EvalRPN(string[] tokens)
        {
            Stack<int> stack = new Stack<int>();
            // HashSet<char> charSet = new HashSet<char>{'+', '-', '*', '/'};
            for(int i = 0; i < tokens.Length; i++)
            {
                if(int.TryParse(tokens[i], out int num))
                {
                    stack.Push(num);
                }
                else
                {
                    int num1 = stack.Pop();
                    int num2 = stack.Pop();
                    int result = tokens[i] switch
                    {
                        "+" => num1 + num2,
                        "-" => num2 - num1,
                        "*" => num1 * num2,
                        "/" => num2 / num1,
                        _ => 0
                    };
                    stack.Push(result);
                }
            }
            return stack.Pop();
        }
    }
}
