#include <iostream>


using namespace std;

int main()
{
    int x;
    int y;
    cin >>  x;
    cin >> y;

    if (x < y){
        cout << x;
        cout << " ";
        cout << y;
    }else{
        cout << y;
        cout << " ";
        cout << x;
    }

    return 0;
}