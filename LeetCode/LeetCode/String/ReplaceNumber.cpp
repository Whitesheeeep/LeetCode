#include <iostream>
#include <string>
#include <cctype>

using namespace std;

int main()
{
    string s;
    cin >> s;
    // cout << s;

    int numCount = 0;
    for (char a : s)
    {
        if (isdigit(a)) numCount++;
    }

    cout<< numCount << endl;
    int slow = s.size() - 1;
    s.resize(numCount * 5 + s.size());
    for(int i = s.size() - 1; i >= 0; i--)
    {
        if (!isdigit(s[slow])) s[i] = s[slow];
        else
        {
            s[i--] = 'r';
            s[i--] = 'e';
            s[i--] = 'b';
            s[i--] = 'm';
            s[i--] = 'u';
            s[i] = 'n';
        } 
        slow--;
    }
    cout<<s<<endl;
}
