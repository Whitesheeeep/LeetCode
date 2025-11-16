using namespace std;

#include <iostream>
#include <vector>
#include <climits>
#include <unordered_map>
#include <priority_queue>

class MyComparasion
{
	public:
	bool operator()(const pair<int, int>& lhs, const pair<int,int>& rhs)
	{
		return lhs.second > rhs.second;
	}
}

void MyMethod()
{
	int count;
	cin >> count;

	vector<int> nums;
	int input;
	while(count--)
	{
		cin >> input;
		nums.push_back(input);
	}

	int k;
	cin >> k;

	// 统计频率
	unordered_map<int, int> countMap;
	for(int i = 0; i < nums.size(); i++)
	{
		countMap[nums[i]]++;
	}

	priority_queue<pair<int, int> , pair<int, int>, MyComparasion> pri_que;
	
}


int main()
{
	while (true)
		MyMethod();
	
	
}
