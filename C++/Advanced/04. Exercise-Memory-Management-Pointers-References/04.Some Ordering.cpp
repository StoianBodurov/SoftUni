#include <iostream>

using namespace std;

int main(){

    string data;
    getline(cin, data);

    string* pntr = &data;

    for (char el: *pntr){
        cout << (char)tolower(el);
    }

    cout << endl;
    for (char el: *pntr){
        cout << (char)toupper(el);
    }


    return 0;
}