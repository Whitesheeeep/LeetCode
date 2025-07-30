#include <vector>
#include <string>

using namespace std;	

class LeetCode438_FindAnagrams_middle
{
//方法二：
public:
	vector<int> findAnagrams(string s, string p)
	{
		if (s.size() < p.size()) return {};
		//vector<int> s_cnt(26,0) 这是 vector<int> 的一种初始化方式，表示初始化一个大小为26，值为0的vector
		//vector<int> vector(size_type count, const T& value, const Allocator& alloc = Allocator());
		//count 表示初始化的大小，value表示初始化的值，alloc表示分配器
		vector<int> res, count(26, 0);
		int differ = 0;
		//初始化count数组，并且比较 index 为 0 是否符合异构词
		for (int i = 0; i < p.size(); i++)
		{
			++count[s[i] - 'a'];
			--count[p[i] - 'a'];
		}
		for (int i = 0; i < 26; i++)
		{
			if (count[i] != 0) ++differ;
		}
		if (differ == 0)	res.emplace_back(0);

		//int left = i + 1, right = i + p.size();
		for (int i = 0; i < s.size() - p.size(); i++)
		{
			//左边界移动
			// 原本窗口中的元素 count[s[i]-'a'] 只可能是 0 或 1，0 表示s[i]在p中出现过，1表示s[i]在p中没有出现过
			// 这里的count[s[i] - 'a'] == 1表示将要被去除的s[i] 在 p 中没有，所以去除后 differ 要减1
			// 这里的count[s[i] - 'a'] == 0表示s[i]在p中出现过，所以differ要加1
			if (count[s[i] - 'a'] == 1) --differ;
			else if (count[s[i] - 'a'] == 0) ++differ;
			--count[s[i] - 'a'];

			//右边界移动
			if (count[s[i + p.size()] - 'a'] == -1) --differ;
			else if (count[s[i + p.size()] - 'a'] == 0) ++differ;
			++count[s[i + p.size()] - 'a'];

			if (differ == 0) res.push_back(i + 1);
		}
		return res;

	}
};