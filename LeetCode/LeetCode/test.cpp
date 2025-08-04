#include <unordered_set>
#include <vector>
#include <iostream>
#include <unordered_map>

using namespace std;

int main()
{
	unordered_map<int, int> myMap;
	myMap[1]= 1;
	for(auto i : myMap)
		cout << i.first << " " << i.second;
}


