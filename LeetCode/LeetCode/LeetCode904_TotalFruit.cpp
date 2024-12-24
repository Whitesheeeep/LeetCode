#include <unordered_map>
#include <vector>

using namespace std;

class Solution {
public:
    int totalFruit(vector<int>& fruits) {
        int n = fruits.size();
		//����map��keyΪˮ�����࣬valueΪˮ������
		//++cnt[fruits[right]] �����Զ��ж� [] �е� fruits[right] �Ƿ����
		//��� fruit[right] �����ڣ�cnt ���Զ����һ���µļ�ֵ�ԣ�ֵΪ 0
		//�� cnt ǰ����һ�� ++�����ԻὫֵ�� 1
		//��� fruit[right] ���ڣ��ͻ��ҵ������ֵ�ԣ�Ȼ��ֵ�� 1
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