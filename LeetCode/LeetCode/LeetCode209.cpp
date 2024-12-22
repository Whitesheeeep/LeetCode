#include <cstdint>
#include <vector>

using namespace std;

class Solution {
public:
    int minSubArrayLen(int s, vector<int>& nums) {
        int result = INT32_MAX;
        int sum = 0; // ����������ֵ֮��
        int i = 0; // ����������ʼλ��
        int subLength = 0; // �������ڵĳ���
        for (int j = 0; j < nums.size(); j++) {
            sum += nums[j];
            // ע������ʹ��while��ÿ�θ��� i����ʼλ�ã��������ϱȽ��������Ƿ��������
            while (sum >= s) {
                subLength = (j - i + 1); // ȡ�����еĳ���
                result = result < subLength ? result : subLength;
                sum -= nums[i++]; // �������ֳ��������ڵľ���֮�������ϱ��i�������е���ʼλ�ã�
            }
        }
        // ���resultû�б���ֵ�Ļ����ͷ���0��˵��û�з���������������
        return result == INT32_MAX ? 0 : result;
    }
};