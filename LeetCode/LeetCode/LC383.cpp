#include <string>
#include <unordered_map>

using namespace std;

class Solution {
public:
	bool canConstruct(string ransomNote, string magazine) {
		if (ransomNote.size() > magazine.size()) return false;
		
		unordered_map<char, int> charCount;
		for (const auto& a : charCount)
		{
			charCount[a.first]++;
		}

		for (const char b : ransomNote)
		{
			if (charCount.find(b) == charCount.end() || charCount[b] == 0) return false;
			else
			{
				charCount[b]--;
			}
		}
		return true;


	}
};