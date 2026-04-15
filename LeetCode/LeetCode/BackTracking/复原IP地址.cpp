#include <iostream>
#include <string>
#include <vector>

using namespace std;

vector<string> res;

bool isValid(const string& s){
	if (s.empty() || s.size() == 0 || s.size() > 3) return false;
	if (s.size() > 1 && s[0] == '0') return false;
	if (stoi(s) > 255) return false;
	return true;
}

void backTracking(string input, string path, int startIndex, int dotCount){
	// if (dotCount == 4)
	// {
	// 	path.pop_back();
	// 	res.push_back(path);
	// 	return;
	// }

	// 包含 startIndex
	for (int i = startIndex + 1; i <= input.size(); i++) {
		string str;
		if (dotCount == 3) {
			str = input.substr(startIndex);
			if (isValid(str)){
				res.push_back(path+str);
				return;
			}
		}
		else str = input.substr(startIndex, i - startIndex);

		if (isValid(str)){
			backTracking(input, path + str + '.', i, dotCount + 1);
		}
		else break;
	}
}

int main()
{
	while (true)
	{string input;
	cin >> input;

	string path = "";
	backTracking(input, path, 0, 0);

	for (string r : res) {
		cout << r << " " <<  endl;
	}}
}
