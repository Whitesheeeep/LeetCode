#include <unordered_map>
#include <vector>

using namespace std;

class Solution {
public:
    int totalFruit(vector<int>& fruits) {
        int n = fruits.size();
		//无序map，key为水果种类，value为水果数量
		//++cnt[fruits[right]] ：会自动判断 [] 中的 fruits[right] 是否存在
		//如果 fruit[right] 不存在，cnt 会自动添加一个新的键值对，值为 0
		//但 cnt 前面有一个 ++，所以会将值加 1
		//如果 fruit[right] 存在，就会找到这个键值对，然后将值加 1
        unordered_map<int, int> cnt;

        int left = 0, ans = 0;
        for (int right = 0; right < n; ++right) {
            ++cnt[fruits[right]];
            while (cnt.size() > 2) {
                auto it = cnt.find(fruits[left]);
                --it->second;
                if (it->second == 0) {
                    cnt.erase(it);
                }
                ++left;
            }
            ans = max(ans, right - left + 1);
        }
        return ans;
    }
};