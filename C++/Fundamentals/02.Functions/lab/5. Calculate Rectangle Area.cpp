#include <iostream>
#include <string>

using namespace std;

int rectangleArea(int a, int b){
    return a * b;
}

int main()
{
    int a;
    int b;
    cin >> a;
    cin >> b;


    rectangleArea(a, b);

    return 0;
}