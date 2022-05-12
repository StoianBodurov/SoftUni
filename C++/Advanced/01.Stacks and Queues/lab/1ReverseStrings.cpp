#include <iostream>
#include <stack>


using namespace std;

void printStck(stack<char> data){
    while (!data.empty())
    {
        cout << data.top();
        data.pop();

    }
    
}


int main(){
    string text;
    getline(cin, text);

    stack<char> stack;


    for (int i = 0; i < text.size(); i++){
        stack.push(text[i]);
    }

    printStck(stack);
    return 0;
}

