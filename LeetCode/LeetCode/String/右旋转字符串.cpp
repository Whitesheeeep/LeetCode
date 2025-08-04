#include <iostream>
#include <algorithm>

using namespace std;

void rightRotate(string &s, int k)
{
    int num = s.size() - k;

    while (num--)
    {
        int ptr = num;
        for(int i = 0; i < k; i++)
        {
            swap(s[ptr], s[ptr + 1]);
            ptr++;
        }
    }
}

int main()
{
    int k;
    string s;
    while(true)
    { 
        // 输入
        cin >> k;
        cin >> s;
        int len = s.size() - k;
        // 右旋
        // rightRotate(s, k);
        reverse(s.begin(), s.end());
        reverse(s.begin(), s.begin() + k);
        reverse(s.begin() + k, s.end());

        cout << s << endl;
    }
}
