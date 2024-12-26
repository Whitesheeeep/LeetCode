#include <string>
#include <stack>
#include <unordered_map>

using namespace std;

class Solution {
public:
    bool isValid(string s) {
        stack<int> stack;

        unordered_map<char, char> map = {
            {')', '('},
            {']', '['},
            {'}', '{'}
        };

        for (char c : s)
        {
            if (map.count(c))
            {
                if (stack.empty() || stack.top() != map[c])
                {
                    return false;
                }
				stack.pop();
            }
            else
            {
				stack.push(c);
            }
        }

        return stack.empty();
    }
};