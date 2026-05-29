#include <iostream>
#include <vector>

using namespace std;

vector<int> getNext(string s){
	vector<int> next(s.size(), 0);
	int len= 0;
	for (int i = 1; i < s.size(); i++) {
		if (s[len] == s[i]) {
			len++;
			next[i] = len;
		}
		else {
			if (len == 0) {
				s[i] = 0;
			}
			else {
				len = next[len - 1];
				i--;
			}
		}
	}
	return next;
}

int firstMatchString(string s1, string s2){
	vector<int> next = getNext(s2);

	int p = 0, res = 0;
	for (int i = 0; i < s1.size(); i++) {
		if (s1[i] == s2[p]) {
			if (p == s2.size()) {
				return i - p + 1;
			}
			p++;
		}
		else if(p > 0){
			p = next[p - 1];
			i--;
		}
	}
	return -1;
}

int main(){

}
