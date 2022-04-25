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

    int result[arrayLength * arrayLength];
    int index = 0;

    for (int i = 0;i < arrayLength; i++){
        for (int j = 0; j < arrayLength; j++){
            result[index] = array[i] * array[j];
            index++;
        }
    }

    for (int i = 0;i < (arrayLength * arrayLength);i++){
        cout << result[i] << ' ';
    }
    return 0;
}