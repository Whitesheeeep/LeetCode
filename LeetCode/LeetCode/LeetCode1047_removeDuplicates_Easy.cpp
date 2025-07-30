#include <string>
#include <stack>

using namespace std;

class LeetCode438_FindAnagrams_middle {
public:
    string removeDuplicates(string s) {
        stack<char> stack;
		for (char c : s)
		{
			if (!stack.empty() && stack.top() == c)
			{
				stack.pop();
			}
			else
			{
				stack.push(c);
			}
		}

		string result = "";
		while (!stack.empty())
		{
			result = stack.top() + result;
			stack.pop();
		}
		return result;
    }
};