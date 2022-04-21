#include <iostream>
#include <string>

using namespace std;

void printTriamgle(int n){
    for (int i = 1; i <= n; i++){
        for (int j = 1; j <= i; j++){
            cout << to_string(j) + " ";

        }
        cout << endl;
    }

        for (int i = n - 1; i >= 1; i--){
        for (int j = 1; j <= i; j++){
            cout << to_string(j) + " ";

        }
        cout << endl;
    }
}


int main()
{
    int x;
    cin >> x;


    printTriamgle(x);

    return 0;
}