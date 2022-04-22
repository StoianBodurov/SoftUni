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
    cin >> o;
    calculator(a, b, o);

    return 0;
}