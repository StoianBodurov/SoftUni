#include <iostream>

using namespace std;

void readArray(int arr[], int length){
    for (int i = 0; i < length; i++){
        int n;
        cin >> n;
        arr[i] = n;

    }
}

bool isEqualArrays(int arr1[], int lengthArr1, int arr2[], int lengthArr2){
    if (lengthArr1 != lengthArr2){
        return false;
    }

    for (int i = 0; i < lengthArr1; i++){
        if (arr1[i] != arr2[i]){
            return false;
        }
    }

    return true;   
}

int main(){

    int arr1Length;
    int arr2Length;
    
    cin >> arr1Length;
    int array1[arr1Length];
    readArray(array1, arr1Length);

    cin >> arr2Length;
    int array2[arr2Length];
    readArray(array2, arr2Length);


    if (isEqualArrays(array1, arr1Length, array2, arr2Length)){
        cout << "equal";
    } else {
        cout << "Not equal";
    }
    


    return 0;
}