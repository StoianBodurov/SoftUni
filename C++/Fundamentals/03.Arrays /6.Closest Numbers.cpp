#include <iostream>

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
    int minDiff = INT8_MAX;

    for (int i = 0; i < arrayLength; i++){
        for (int j = 0; j < arrayLength; j++){
            if (i == j){
                continue;
            }
            int tempDiff = array[i] - array[j];
            if (tempDiff < 0){
                tempDiff *= -1;
            }

            if (minDiff >= tempDiff){
                minDiff = tempDiff;
            }
        }
    }

    cout << minDiff;
    return 0;
}