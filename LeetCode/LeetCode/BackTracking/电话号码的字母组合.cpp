#include <iostream>
#include <string>
#include <vector>
#include <unordered_map>

using namespace std;

unordered_map<char, vector<char>> phoneMap {
	{'2' , {'a', 'b', 'c'}},
	{'3' , {'d', 'e', 'f'}},
	{'4' , {'g', 'h', 'i'}},
	{'5' , {'j', 'k', 'l'}},
	{'6' , {'m', 'n', 'o'}},
	{'7' , {'p', 'q', 'r', 's'}},
	{'8' , {'t', 'u', 'v'}},
	{'9' , {'w', 'x', 'y', 'z'}}
};

void backTracking(string& digits, vector<string>& res, int startIndex, string& path){
	if (path.size() == digits.size()){
		res.push_back(path);
		return;
	}

	for (int i = startIndex; i < digits.size(); i++)
	{
		for (int j = 0; j < phoneMap[digits[i]].size(); j++) {
			path.push_back(phoneMap[i][j]);
			backTracking(digits, res, i+1, path);
			path.pop_back();
		}
	}
}

int main(){
	string digits;
	cin >> digits;

	vector<string> res;
	string path="";
	backTracking(digits, res, 0, path);

	// 输出
	for (auto s : res) {
		cout << s << endl;
	}
}
