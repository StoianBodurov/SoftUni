# include <iostream>
#include <stack>


using namespace std;

void printExpression(string str, int start, int end){
    for (int i = start; i <= end; i++){
        cout << str[i];
    }

    cout << endl;
}


int main(){

    string data;
    getline(cin, data);

    stack<int> startIndex;

    for (int i = 0; i < data.length(); i++){
        if (data[i] == '('){
            startIndex.push(i);
        }

        if (data[i] == ')'){
            printExpression(data, startIndex.top(), i);
            startIndex.pop();
        }
    }

    return 0;
}