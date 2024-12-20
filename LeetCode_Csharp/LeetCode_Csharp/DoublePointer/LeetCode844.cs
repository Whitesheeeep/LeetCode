using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_Csharp
{
    public class LeetCode844
    {
        //Solution1:双指针，但是 StringAfterBackSpace 函数中空间复杂度为 O(n)，因为创建了一个与string s 长度相同的数组
        //这样就会导致空间复杂度为 O(n)
        public bool BackSpaceCompare(string s, string t)
        {
            return StringAfterBackSpace(s).Equals(StringAfterBackSpace(t));
        }

        public string  StringAfterBackSpace(string s)
        {
            char[] chars = s.ToCharArray();
            int slow = 0;
            for (int fast = 0; fast < chars.Length; fast++)
            {
                if(chars[fast] != '#')
                {
                    chars[slow++] = chars[fast];
                }
                else
                {
                    if(slow > 0)
                    {
                        slow--;
                    }
                }
            }
            return new string(chars, 0, slow);
        }

        //Solution2: 双指针，空间复杂度为 O(1)
        public bool BackSpaceCompare2(string s, string t)
        {
            int skip1 = 0, skip2 = 0;
            int index1 = s.Length - 1, index2 = t.Length - 1;
            while (index1 >= 0 || index2 >= 0) {
                while (index1 >= 0 && (s[index1] == '#' || skip1 > 0)) {
                    if (s[index1] == '#') {
                        skip1++;
                    } else {
                        skip1--;
                    }
                    index1--;
                }
                while (index2 >= 0 && (t[index2] == '#' || skip2 > 0)) {
                    if (t[index2] == '#') {
                        skip2++;
                    } else {
                        skip2--;
                    }
                    index2--;
                }
                if (index1 >= 0 && index2 >= 0) {
                    if (s[index1] != t[index2]) {
                        return false;
                    }
                } else if (index1 >= 0 || index2 >= 0) {
                    return false;
                }
                index1--;
                index2--;
            }
            return true;
        }


    }
}