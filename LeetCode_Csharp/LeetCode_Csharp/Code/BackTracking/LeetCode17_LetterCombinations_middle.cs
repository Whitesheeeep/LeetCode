using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.BackTracking
{
    public class LeetCode17_LetterCombinations_middle
    {
        private Dictionary<char, string> NumLetterPairs = new();
        public IList<string> LetterCombinations(string digits)
        {
            string path = "";
            List<string> res =[];
            // 存储每个数字代表的字母组
            InitNumLetterPairs();
            BackTracking(digits, 0, path, res);
            return res;
        }

        private void InitNumLetterPairs()
        {
            NumLetterPairs.Add('2', "abc");
            NumLetterPairs.Add('3', "def");
            NumLetterPairs.Add('4', "ghi");
            NumLetterPairs.Add('5', "jkl");
            NumLetterPairs.Add('6', "mno");
            NumLetterPairs.Add('7', "pqrs");
            NumLetterPairs.Add('8', "tuv");
            NumLetterPairs.Add('9', "wxyz");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="k"> k 表示最后需要的数组的长度 </param>
        private void BackTracking(in string digits, int index, string path, List<string> res)
        {
            if (path.Length == digits.Length)
            {
                res.Add(path);
                return;
            }
            if(index >= digits.Length) return;

            // letters 存储当前数字代表的字母组
            string letters = NumLetterPairs[digits[index]];
            for (int i = 0; i < letters.Length; i++)
            {
                BackTracking(digits, index + 1, path + letters[i], res);
            }
        }
    }
}
