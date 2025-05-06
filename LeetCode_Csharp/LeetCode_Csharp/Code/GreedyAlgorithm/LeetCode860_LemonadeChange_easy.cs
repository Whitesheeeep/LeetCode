using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.GreedyAlgorithm
{
    public class LeetCode860_LemonadeChange_easy
    {
        public bool LemonadeChange(int[] bills)
        {
            int count_5 = 0, count_10 = 0;
            for(int i = 0; i < bills.Length; i++)
            {
                if(bills[i] == 5) count_5++;
                else if(bills[i] == 10)
                {
                    if(count_5 < 1) return false;
                    else
                    {
                        count_5--;
                        count_10++;
                    }
                }
                else if(bills[i] == 20)
                {
                    if(count_10 > 0 && count_5 > 0)
                    {
                        count_10--;
                        count_5--;
                    }
                    else if(count_5 >= 3)
                    {
                        count_5 -= 3;
                    }
                    else return false;
                }
            }
            return true;
        }
    }
}
