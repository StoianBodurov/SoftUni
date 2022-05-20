#include <iostream>
#include <sstream>
#include <stack>
#include <algorithm>


using namespace std;

int getMaxNumber(stack<int> data){
    int maxElement = 0;
    stack<int> temp;
    if (!data.empty()){
        maxElement = data.top();
        temp.push(data.top());
        data.pop();
    }

    while (!data.empty())
    {
        int el = data.top();
        if (el > maxElement){
            maxElement = el;
        }
        temp.push(el);
        data.pop();

    }

    while (!temp.empty())
    {
        data.push(temp.top());
        temp.pop();
    }
    
    

    return maxElement;
}

int getMinNumber(stack<int> data){
    int minElement = 0;
    stack<int> temp;
    if (!data.empty()){
        minElement = data.top();
        temp.push(data.top());
        data.pop();
    }

    while (!data.empty())
    {
        int el = data.top();
        if (el < minElement){
            minElement = el;
        }
        temp.push(el);
        data.pop();

    }

    while (!temp.empty())
    {
        data.push(temp.top());
        temp.pop();
    }
    
    

    return minElement;
}

int main(){

    string input;
    getline(cin,input);
    int n = stoi(input);

    stack<int> numbers;

    for (int i = 0; i < n; i++){
        string data;
        getline(cin, data);
        stringstream ss(data);
        int command;
        ss >> command;

        switch (command)
        {
        case 1:
            int number;
            ss >> number;
            numbers.push(number);

            break;
        
        case 2:
            if (!numbers.empty()){
                numbers.pop();

            }
            break;

        case 3:
            if(!numbers.empty()){
                cout << getMaxNumber(numbers) << endl;
            }

            break;

        case 4:
            if(!numbers.empty()){
                cout << getMinNumber(numbers) << endl;
            }
            
            break;
        }
    }
    while (!numbers.empty())
    {
        cout << numbers.top();
        numbers.pop();
        if(!numbers.empty()){
            cout << ", ";
        }
    }

    cout << endl;
    
    return 0;
}