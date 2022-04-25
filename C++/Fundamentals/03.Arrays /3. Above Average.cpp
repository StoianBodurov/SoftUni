#include <iostream>

using namespace std;

void readArray(int arr[], int length){
    for (int i = 0; i < length; i++){
        int n;
        cin >> n;
        arr[i] = n;

    }
}

double getArrayAverageSum(int arr[], int arrLength){
    double sum = 0;

    for (int i = 0; i < arrLength; i++){
        sum += arr[i];
    }

    return sum / arrLength;
}

int main(){

    int arrLength;
    
    cin >> arrLength;
    int array[arrLength];
    readArray(array, arrLength);
    double averageOfArrayNumber= getArrayAverageSum(array, arrLength);

    for (int i =  0;i < arrLength; i++){
        if (array[i] >= averageOfArrayNumber){
            cout << array[i] << ' ';
        }
    }

    
    return 0;
}