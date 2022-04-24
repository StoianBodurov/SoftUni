#include <iostream>

using namespace std;

void calculator(int a, int b, char operations){
    switch (operations){
        case '/':
            if (b == 0){
                cout  << "Can't divide by zero.";

            }else {
                cout << a / b;
            }
            break;
        case '*':
            cout << a * b;
            break;
        case '+':
            cout << a + b;
            break;
        case '-':
            cout << a - b;
            break;

    }

}

int main(){
    int a;
    int b;
    char o;
    cin >> a;
    cin >> b;
    bool isInCorectOperator = true;
    while (isInCorectOperator)
    {
        cin >> o;
        if (o == '/' || o == '*' || o == '-' || o == '+'){
            isInCorectOperator = false;
        } else {
            cout << "try again" << endl;
        }
        

    }
 

    calculator(a, b, o);

    return 0;
}