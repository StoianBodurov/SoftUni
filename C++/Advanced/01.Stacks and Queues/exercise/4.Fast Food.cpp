#include <iostream>
#include <sstream>
#include <queue>

using namespace std;

int main(){

    string data;
    getline(cin, data);
    int quantity = stoi(data);

    getline(cin, data);

    queue<int> orders;
    stringstream ss(data);
    int n;

    while (ss >> n)
    {
        orders.push(n);
    }
    int biggestOrder = 0;
    while (!orders.empty())
    {
        int currentOrder = orders.front();

        if (quantity >= currentOrder){
            quantity -= currentOrder;
            orders.pop();

            if (currentOrder > biggestOrder){
                biggestOrder = currentOrder;
            }

        }else{
            break;
        }

       
    }
    cout << biggestOrder << endl;
    if (orders.empty()){
        cout << "Orders complete" << endl;
    }else{
        cout << "Orders left: ";
        while (!orders.empty())
        {
            int currentOrder = orders.front();
            cout << currentOrder<< " "; 
            orders.pop();
        }
        
    }

    return 0;
}