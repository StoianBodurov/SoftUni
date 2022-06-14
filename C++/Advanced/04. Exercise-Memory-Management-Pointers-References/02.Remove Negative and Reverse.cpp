#include <iostream>
#include <vector>
#include <sstream>

using namespace std;

void readInput(vector<int> & num){
    string data;
    getline(cin, data);

    stringstream ss(data);

    int n;
    while (ss >> n)
    {
        num.push_back(n);
    }
}


int main(){
    vector<int> numbers;
    readInput(numbers);

    bool isEmpty = true;

    for (auto i = numbers.rbegin(); i != numbers.rend(); i++){
        if (*i >= 0){
            isEmpty = false;
            cout << *i << " ";
        }
    }

    if (isEmpty){
        cout << "empty";
    }
    cout << endl;

    return 0;
}