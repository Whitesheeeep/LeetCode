#include <iostream>
#include <string>
#include <vector>

using namespace std;

bool canComposite(vector<string> &wordDict, string s) { 
	// dp[i] 表示窗口 0 - i 组成的单词能够由 wordDict 组成
	vector<bool> dp(s.size() + 1, false);
	int startIndex = -1;
	for (int i = 0; i < wordDict.size(); i++) {
		if (s.substr(0, wordDict[i].size()) == wordDict[i]) {
			dp[wordDict[i].size()-1] = true;
			if (dp[wordDict[i].size()-1]) {
				startIndex = wordDict[i].size();
				cout << "startIndex: "<< startIndex << endl;
				break;
			}
		}
	}
	if (startIndex == -1) {
		return false;
	}

	for (int i = startIndex; i < s.size(); i++) {
		for (int j = 0; j < wordDict.size(); j++) {
			cout << "index: " << i << " " << j << endl;
			if (wordDict[j].size() <= i && i + wordDict[i].size() < s.size()) {
				dp[i] = dp[i-wordDict[j].size()] && (wordDict[j] == s.substr(i-wordDict[j].size(), wordDict[i].size()));
				
			}
			if (dp[i]) {
				break;
			}
		}
	}

	return dp[s.size() - 1]; 
}

int main() {
	string t1 = "abcd";
	vector<string> test1{"ab", "c"};
	cout << canComposite(test1, t1) << endl;

    string s, word;
    int n;
    cin >> n;
    vector<string> wordDict;
    while (n--) {
        cin >> word;
        wordDict.push_back(word);
    }
}
