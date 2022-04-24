#include <iostream>

using namespace std;

void multiplyEvensOddsSum(int a){
    int evenSum = 0;
    int oddSum = 0;

    while (a != 0)
    {
        int digit = a % 10;
        a /= 10;
        if (digit % 2 == 0){
            evenSum += digit;
        } else {
            oddSum += digit;
        }
    }

    cout << evenSum * oddSum;
    
    

}

int main(){

    int number;
    cin >> number;

    multiplyEvensOddsSum(number);
    return 0;
}