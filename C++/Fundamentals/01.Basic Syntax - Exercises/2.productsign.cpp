#include <iostream>


using namespace std;

int main()
{
    double x;
    double y;
    double z;
    cin >> x;
    cin >> y;
    cin >> z;

    int countNegativ = 0;


    if (0 >  y){
        countNegativ++;
    };

    if (0 > z){
        countNegativ++;
    };

    if (0 > x){
        countNegativ++;
    };

    if (countNegativ % 2 == 0){
        cout << "+";
    }else{
        cout << "-";
    }
    return 0;
}