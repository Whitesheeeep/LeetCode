using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.DoublePointer
{
    public class 替换数字
    {
        public static void MainMethod()
        {
            string s = Console.ReadLine();

            int numCount = 0;
            foreach (char c in s)
            {
                if (char.IsDigit(c))
                    numCount++;
            }

            char[] newChars = new char[s.Length + numCount * 5];
            int slow = s.Length - 1;
            int fast = newChars.Length - 1;

            while (slow >= 0)
            {
                if (char.IsDigit(s[slow]))
                {
                    newChars[fast--] = 'r';
                    newChars[fast--] = 'e';
                    newChars[fast--] = 'b';
                    newChars[fast--] = 'm';
                    newChars[fast--] = 'u';
                    newChars[fast--] = 'n';
                }
                else
                {
                    newChars[fast--] = s[slow];
                }
                slow--;
            }
            Console.WriteLine(new string(newChars));
        }
    }
}
