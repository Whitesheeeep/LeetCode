#include <string>
#include <iostream>

using namespace std;

class Solution
{
public:
	bool isAnagram(string s, string t)
	{
		if (s.size() != t.size()) return 0;
		int* alpha = new int[26];
		for (char i : s) alpha[i - 'a']++;
		for (char i : t)
		{
			if (alpha[i - 'a'] == 0) return false;
			else
			{
				alpha[i - 'a']--;
			}
		}
		return true;
	}
};