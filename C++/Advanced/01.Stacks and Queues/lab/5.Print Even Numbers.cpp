#include <iostream>
#include <queue>
#include <sstream>


using namespace std;

int main(){

    string data;
    getline(cin, data);
    stringstream ss(data);

    queue<int> numbers;
    int n;

    while ( ss >> n)
    {
        numbers.push(n);
    }

    while (!numbers.empty())
    {
        int num;

        num = numbers.front();
        numbers.pop();

        if (num % 2 == 0){
            cout << num << ", ";
        }
    }

    cout << endl;
    return 0;
}