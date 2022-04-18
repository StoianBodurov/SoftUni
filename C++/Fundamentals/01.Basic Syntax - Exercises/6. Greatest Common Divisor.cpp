#include <iostream>
#include <algorithm>



using namespace std;

int main()
{
  int x;
  int y;
  int greatestDivisor;

  cin >> x;
  cin >> y;

  int smaller = min(x, y);

  for (int i = 1;i <= smaller; i++){
      if (x % i == 0 && y % i == 0){
          greatestDivisor = i;
      }
  }

    cout << greatestDivisor;
    return 0;
}