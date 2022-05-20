#include <iostream>
#include <sstream>
#include <stack>

using namespace std;

int main(){

    string data;
    getline(cin, data);

    int capacity;
    cin >> capacity;

    stack<int> delivery;
    stringstream ss(data);
    int n;

    while (ss >> n)
    {
        delivery.push(n);
    }

    int boxCount = 1;
    int clothesQuantity = 0;

    while (!delivery.empty())
    {
        int cuurentQuantity = delivery.top();

        if (cuurentQuantity + clothesQuantity <= capacity){
            clothesQuantity += cuurentQuantity;
           
        }else{
            boxCount++;
            clothesQuantity = cuurentQuantity;
        }
         delivery.pop();
    }

    cout << boxCount << endl;
    
    
    return 0;
}