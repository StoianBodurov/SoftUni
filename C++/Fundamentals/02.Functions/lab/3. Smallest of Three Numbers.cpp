#include <iostream>
#include <string>

using namespace std;


void smallestNumber(int x, int y, int z){
    if (x < y && x < z){
        cout << x;
    } else if(y < x && y < z){
        cout << y;
    }else {
        cout << z;
    }
}

int main()
{
    int x;
    int y;
    int z;
    cin >> x;
    cin >> y;
    cin >> z;


    smallestNumber(x, y, z);

    return 0;
}