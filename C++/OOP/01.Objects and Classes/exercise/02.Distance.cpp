#include <iostream>
#include <math.h>
#include <iomanip>

using namespace std;

class Point{
    public:
        int x;
        int y;
        
    Point(istream & istr){
        istr >> x >> y;
    }
        
    double getDistance(Point p2){
        return sqrt(pow(x - p2.x, 2) + pow(y - p2.y, 2));
    }
};

int main(){
    Point p1(cin);
    Point p2(cin);
    
    cout << setprecision(3) << fixed << p1.getDistance(p2);
    return 0;
}