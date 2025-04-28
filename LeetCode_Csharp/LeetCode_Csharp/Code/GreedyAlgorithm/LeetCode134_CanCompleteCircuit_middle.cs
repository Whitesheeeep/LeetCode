namespace LeetCode_Csharp.Code.GreedyAlgorithm
{
    public class LeetCode134_CanCompleteCircuit_middle
    {
        public int CanCompleteCircuit(int[] gas, int[] cost)
        {
            if(gas.Length == 1) return gas[0] - cost[0] >= 0 ? 0 : -1;

            int gasMax = int.MaxValue, gasMaxIndex = 0;
            int gasCostSubFromZero = 0;
            int gasCostSubFromValid = 0;
            int index = 0;
            bool startSum = false;
            for (int i = 0; i < gas.Length; i++)
            {
                if(i > 0) gasCostSubFromZero += gas[i - 1] - cost[i - 1];
                gasMax = gasCostSubFromZero < gasMax ? gasCostSubFromZero : gasMax;
                // 收集从 0 开始到 i 站所缺少的油量
                // 用于判断从数组的末尾站到初始站需要至少需要多少油量才能到达首站

                int gasCost = gas[i] - cost[i];
                if(gasCost >= 0 && startSum == false)
                {
                    gasMaxIndex = gasMax;
                    startSum = true;
                    index = i;
                }

                if(startSum == true)
                {
                    gasCostSubFromValid += gasCost;
                    if(gasCostSubFromValid < 0)
                    {
                        startSum = false;
                        gasCostSubFromValid = 0;
                    }
                    if(i == gas.Length - 1 && gasCostSubFromValid >= -gasMaxIndex)
                        return index;
                }
                
                
            }

            return -1;
        }
    }
}
