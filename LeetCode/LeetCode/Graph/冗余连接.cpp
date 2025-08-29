#include <iostream>
#include <vector>

#include "并查集模板.H"

using namespace std;

int main()
{
    int n,m; // 顶点，边
    Set s;
    s.n = n;

    while(m--)
    {
        int a,b;
        cin >> a >> b;
        if(s.isSame(a,b))
        {
            cout << a << " " << b << endl;
            return 0;
        }
        else
        {
            s.join(a,b);
        }
    }
}
