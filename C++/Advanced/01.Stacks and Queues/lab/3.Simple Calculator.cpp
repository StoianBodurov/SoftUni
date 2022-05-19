#include <iostream>
#include <sstream>
#include <stack>

using namespace std;


int main(){

    string input;
    getline(cin, input);
    stringstream ss(input);
    stack<int> numbers;
    stack<char> operations;
    int bember;
    char operation;

    while (ss >> bember)
    {
        numbers.push(bember);

        if(ss >> operation){
            operations.push(operation);
        }
    }

    int result = 0;

    while (!numbers.empty())
    {
        int n;
        n = numbers.top();
        numbers.pop();

        char op;
        if (!operations.empty()){
            op = operations.top();
            operations.pop();

            if (op == '-'){
                n *= -1;
            }
        }

        

        result += n;
    }
    
    
    cout << result << endl;

    return 0;
}