#include <iostream>
#include <string>
#include <vector>

using namespace std;

bool canComposite(vector<string> &wordDict, string s) { 
	// dp[i] 表示窗口 0 - (i - 1) 组成的单词能够由 wordDict 组成
	vector<bool> dp(s.size() + 1, false);
	dp[0] = true;

	for (int i = 1; i <= s.size(); i++) {
		for (int j = 0; j < wordDict.size(); j++) {
			cout << "index: " << i << " " << j << endl;
			if (wordDict[j].size() <= i ) {
				cout << wordDict[j] << " " << s.substr(i -wordDict[j].size(), wordDict[j].size()) << endl;
				dp[i] = dp[i-wordDict[j].size()] && (wordDict[j] == s.substr(i -wordDict[j].size(), wordDict[j].size()));
				
			}
			cout << dp[i] << endl;
			if (dp[i]) {
				break;
			}
		}
	}

	return dp[s.size()]; 
}

int main() {
	string t1 = "abcd";
	vector<string> test1{"ab", "cd"};
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
