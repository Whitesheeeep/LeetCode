#include <iostream>
#include <utility>

using namespace std;

string reverseWord(string s) {
    // 去除空格
    int left = 0;
    for (int i = 0; i < s.size(); i++) {
        if (left == 0 && s[i] != ' ')
        {
            s[left++] = s[i];
        }
        else if (s[i] != ' ' && s[left] == ' ') {
            s[++left] = s[i];
        }
        else if (s[i] != ' ' && s[left] != ' ')
        {
            
        }
    }
    s.resize(left);

    cout << "Trim Result: " << s << endl;

    int l = 0, r = s.size() - 1;
    while (l < r) {
        swap(s[l++], s[r--]);
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
