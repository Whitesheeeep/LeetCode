#include <algorithm>
#include <climits>
#include <iostream>
#include <numeric>
#include <vector>

using namespace std;

int findLowestIndex(vector<int>& ratings){
	if (ratings.size() == 1) {
		return 0;
	}
	int preDif = 0, curDif = 0;
	int res = INT_MAX;
	for (int i = 1; i < ratings.size() - 1; i++) {
		if (i > 0) {
			preDif = ratings[i] - ratings[i -1];
			curDif = ratings[i + 1] - ratings[i];
		}
		if (preDif <= 0 && curDif >0) {
			if (res == INT_MAX || ratings[i] < ratings[res]) {
				res = i;
			}
		}
		if ((curDif <= 0 && i == ratings.size() - 2))
        {
            if (res == INT_MAX || ratings[res] < ratings[ratings.size() - 1]) {
				res = ratings.size() - 1;
			}
        }
	}

	if (res == INT_MAX) {
		res = ratings[0] > ratings[ratings.size() - 1] ? ratings.size() - 1:0;
	}
	return res;
}

int candy(vector<int>& ratings){

	int lowIndex = findLowestIndex(ratings);
	cout << lowIndex << endl;
	vector<int> candies(ratings.size() , 0);
	candies[lowIndex] = 1;
	for (int i = lowIndex + 1; i < ratings.size(); i++) {
		if (ratings[i] > ratings[i - 1]) {
			candies[i] = candies[i - 1] + 1;
		}
		else {
			candies[i] = candies[i - 1] - 1;
		}
	}
	for (int i = lowIndex - 1; i >= 0; i--) {
		if (ratings[i] > ratings[i + 1]) {
			candies[i] = candies[i + 1] + 1;
		}
		else {
			candies[i] = candies[i + 1] - 1;
		}
	}

	for (int i = 0;  i< candies.size(); i++) {
		cout << i << " " << candies[i] << endl;
	}

	return accumulate(candies.begin(), candies.end(), 0);
}

int main(){
	int n, k;
	cin >> n;
	vector<int> candies;

	while (n--) {
		cin >> k;
		candies.push_back(k);
	}

	cout << candy(candies);
}
