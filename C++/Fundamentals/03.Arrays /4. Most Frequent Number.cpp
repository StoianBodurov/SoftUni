#include <iostream>
#include <vector>
#include <algorithm>

using namespace std;

void readArray(int arr[], int length){
    for (int i = 0; i < length; i++){
        int n;
        cin >> n;
        arr[i] = n;

    }
}

int main(){

    int arrayLength;
    cin >> arrayLength;
    int array[arrayLength];
    readArray(array, arrayLength);

    int count = 0;
    vector<int> result;

    for (int i = 0;i < (arrayLength / 2 + 1); i++){
        int n = array[i];
        int c = 1;
        vector<int>::iterator it;
        it = (search_n(result.begin(), result.end(), 1, n));
        if (it != result.end()){
            continue;
            }
        for (int j = 0; j < arrayLength; j++){
            if (i == j){
                continue;
            }

            if (array[j]== n){
                c++;
            }
        }
        if (c > count){
            count = c;
            result.clear();
            result.push_back(n);
        } else if (c == count){
            result.push_back(n);
        }
    }

    sort(result.begin(), result.end());
    for (int i = 0; i < result.size(); i++){
        cout << result[i] << ' ';
    }
    return 0;
}