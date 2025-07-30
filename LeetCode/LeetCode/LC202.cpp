#include <unordered_set>
#include <math.h>

using namespace std;

class Solution {
public:
	bool isHappy(int n) {
		unordered_set<int> appeared(n);
		int sum = n;
		while (sum != 1)
		{
			int temp = 0;
			while (sum != 0)
			{
				temp += pow(sum % 10, 2);
				sum /= 10;
			}
			sum = temp;
			if (appeared.count(sum)) return false;
			else appeared.emplace(sum);
		}
		return true;
	}
};