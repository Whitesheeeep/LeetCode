#include <iostream>
#include <string>
#include <unordered_set>

using namespace std;

int longestSubString(string s){
    int res  = 0;
    unordered_set<char> charSet;
    int left = 0; // 闭区间
    for (int i = 0; i < s.size(); i++) {
        while (left < i && charSet.count(s[i])) {
            charSet.erase(s[left]);
            left++;
        }

        charSet.insert(s[i]);
        /* cout << left << " " << i << endl;
        for (char a : charSet) {
            cout << a << " ";
        }
        cout << endl; */
        res = max(res, i - left + 1);
    } 

    return res;
}

void test(string s){
    cout << "TEST START ===========" << endl;
    cout << longestSubString(s) << endl;
    cout << "TEST END ===========" << endl << endl;
}

int main(){
    test("abc");
    test("aaa");
    test("abcdddd");
    test("abbc");
}
