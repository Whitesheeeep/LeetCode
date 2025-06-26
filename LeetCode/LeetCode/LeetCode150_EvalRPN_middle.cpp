#include <stack>
#include <vector>
#include <string>

using namespace std;

class Solution {
public:
    int evalRPN(vector<string>& tokens) {
        stack<int> stack;
		for (string token : tokens)
		{
			if (token == "+" || token == "-" || token == "*" || token == "/")
			{
				int num2 = stack.top();
				stack.pop();
				int num1 = stack.top();
				stack.pop();
				if (token == "+")
				{
					stack.push(num1 + num2);
				}
				else if (token == "-")
				{
					stack.push(num1 - num2);
				}
				else if (token == "*")
				{
					stack.push(num1 * num2);
				}
				else if (token == "/")
				{
					stack.push(num1 / num2);
				}
			}
			else
			{
				stack.push(stoi(token));
			}

		}

		int result = stack.top();
		stack.pop();
		return result;
    }
};