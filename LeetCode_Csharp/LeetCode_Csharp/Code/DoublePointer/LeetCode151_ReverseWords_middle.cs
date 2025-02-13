using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.DoublePointer
{
    public class LeetCode151_ReverseWords_middle
    {
        public string ReverseWords(string s)
        {
            char[] sArray = s.ToCharArray();
            int slow = 0;
            for(int fast = 0; fast < sArray.Length; fast++)
            {
                if(sArray[fast] != ' ')
                {
                    if(slow > 0) sArray[slow++] = ' ';
                    while(fast < sArray.Length && sArray[fast] != ' ')
                        sArray[slow++] = sArray[fast++];
                }
            }

            Array.Resize(ref sArray, slow);
            Array.Reverse(sArray);

            int start = 0;
            for(int end = 0; end <= sArray.Length; end++)
            {
                if(end == sArray.Length || sArray[end] == ' ')
                {
                    Array.Reverse(sArray, start, end - start);
                    start = end + 1;
                }
            }

            return new string(sArray);
        }
    }
}
