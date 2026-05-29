#include <iostream>
#include <utility>

using namespace std;

void reverse(string& s, int left, int right)
{
    while (left < right) {
        swap(s[left++], s[right--]);
    }
}

string reverseWord(string s) {
    // 去除空格
    int left = 0;
    for (int i = 0; i < s.size(); i++) {
        if (s[i] != ' ')
        {
            if (left != 0) {
                s[left++] = ' ';
            }
            while (i < s.size() && s[i] != ' ') {
                s[left++] = s[i++];
            }
        }
    }
    s.resize(left);

    // cout << "Trim Result:-" << s << "-"<< endl;

    reverse(s, 0, s.size() - 1);
    // cout << s << endl;
    
    int  start = 0;
    for (int i = 0; i <= s.size(); i++) {
        if (i > 0 && (s[i] == ' ' || i == s.size())) {
            reverse(s, start, i - 1);\
            start = i + 1;
        }
    }

    return s;
}

void test(string s) {
    cout << "TEST START ==========" << endl;
    cout << reverseWord(s) << endl;
    cout << "TEST END ==========" << endl << endl;
}

int main() {
    test("abc");
    test("   abc   ");
    test("   ab    c   ");
    test("   ab    cd   ");
}
