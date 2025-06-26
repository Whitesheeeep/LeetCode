#include <string>
#include <cctype>

using namespace std;

class Solution
{
public:
	string minWindow(string s, string t)
	{
		// 特殊情况
		if (s.size() < t.size()) return "";

		string res = "";
		int start = 0, end = 0;
		//装载现有滑动窗口中 t 中的内容
		int* t_char_count = new int[128](); // 用于存储 t 中各个字符的要求数量, 'a':97, 'z':122, 'A':65, 'Z': 90
		int tcount = 0; // 表示 t 中要求的字符的总数
		// 因为题目中只存在唯一的这样的字符串，因此不用考虑重置的问题

		// 初始化上述两个用于存储的数据结构
		for (int i = 0; i < t.size(); i++)
		{
			t_char_count[t[i]]++;
			tcount++;
		}


		for (; end < s.size(); end++)
		{
			// 当有窗口的字符在 t_char_count 中仍然存在时，在两个容器中都减去对应的内容
			// 窗口中没有就不处理
			int index = s[end];
			// 对于还未满足的字符，进行总数相减
			if (t_char_count[index] > 0)
			{
				tcount--;
			}
			t_char_count[index]--;

			// 当总数为 0 的时候, 开始移动左边界
			while (start < s.size() && tcount == 0)
			{
				// 如果左边界的字符移动之后会破坏所选字符串中的满足题意的部分
				if (t_char_count[s[start]] == 0)
				{
					// 更新最小字符串
					res = end - start + 1 < res.size() || res == "" ? s.substr(start, end + 1 - start) : res;
					tcount++;
				}

				// 移动左边界
				t_char_count[s[start]]++;
				start++;
			}

		}
		return res;
	}


};