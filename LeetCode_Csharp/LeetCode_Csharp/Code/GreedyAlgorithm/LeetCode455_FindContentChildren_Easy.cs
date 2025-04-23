using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.GreedyAlgorithm
{
    public class LeetCode455_FindContentChildren_Easy
    {
        public int FindContentChildren(int[] g, int[] s)
        {
            // int res = 0;
            Array.Sort(s);
            Array.Sort(g);
            int g_Ptr = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if(g_Ptr >= g.Length) break;
                // 情况：
                // 1. 饼干够吃，就分配给这个孩子，
                if(s[i] >= g[g_Ptr]) g_Ptr++;
                // 2. 饼干不够吃，换更大的
            }
            return g_Ptr;
        }
    }
}
