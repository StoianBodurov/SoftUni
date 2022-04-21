#include <iostream>
#include <string>

using namespace std;

int power(int num,int pow){
    int result = num;

    if (pow == 0){
        return 1;
    }
    for (int i = 1;i < pow; i++){
        result *= num;
    }
    return result;
}

int main()
{
    int num;
    int pow;
    cin >> num;
    cin >> pow;


    cout << power(num, pow);

    return 0;
}