#include <iostream>
#include <string>

using namespace std;

void signInteger(int n){
    string numToStr = to_string(n);
    if (n > 0){
        cout << "The number " + numToStr + " is positive.";
    }else if(n < 0) {
        cout << "The number " + numToStr + " is negative.";
    }else{
        cout << "The number 0 is zero.";
    }
}

int main()
{

    int n;
    cin >> n;
    signInteger(n);

   return 0;
}