#include <iostream>
#include <array>

using namespace std;

void readArray(int arr[], int length){
    for (int i = 0; i < length; i++){
        int n;
        cin >> n;
        arr[i] = n;

    }
}



int main(){

    int arr1Length;
    
    cin >> arr1Length;
    int array1[arr1Length];
    readArray(array1, arr1Length);
    int n;
    int count = 0;

    for (int i = 0; i < arr1Length; i++){
        int tempNum = array1[i];
        int tempCount = 1;

        for (int j = i + 1;j < arr1Length; j++){
            if (tempNum == array1[j]){
                tempCount++;
            }else{
                break;
            }
        } 
        if (count <= tempCount){
            n = tempNum;
            count = tempCount;
        }
                
            
        
      
    }

    for (int i = 0; i < count; i++){
        cout << n << ' ';
    }

    return 0;
}