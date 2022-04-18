#include <iostream>
#include <bits/stdc++.h>


using namespace std;

int main()
{
   int minNumber = INT_MAX;
   int maxNumber = INT_MIN;

   int n;
   cin >> n;

   for (int i = 0; i < n; i++){
       int number;
       cin >> number;

       if (number < minNumber){
           minNumber = number;
       }

       if (number > maxNumber){
           maxNumber = number;      
       }

   }

   cout << minNumber;
   cout << " ";
   cout << maxNumber;
  
    return 0;
}