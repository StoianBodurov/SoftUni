#include <iostream>
#include <sstream>
#include <stack>

using namespace std;


int main(){

    string data;
    string numbersString;
    getline(cin, data);
    getline(cin, numbersString);
    stringstream ss(data);

    int elementNumber;
    int elementToPop;
    int elementToFind;

    ss >> elementNumber;
    ss >> elementToPop;
    ss >> elementToFind;

    stack<int> numbers;
    stringstream s(numbersString);

    int n;
    while (s >> n)
    {
        numbers.push(n);
    }

    for (int i = 0; i < elementToPop; i++){
        if (!numbers.empty()){
            numbers.pop();

        }
    }

    if (numbers.empty()){
        cout << 0 << endl;
    }else{
        bool isPresent = false;
        int minNumber = INT16_MAX;
        while (!numbers.empty())
        {
            int n = numbers.top();
            if (n == elementToFind){
                isPresent = true;
                break;
            }

            if (n < minNumber){
                minNumber = n;
            }

            numbers.pop();
        }
        
        if (isPresent){
            cout << "true" << endl;
        }else{
            cout << minNumber << endl;
        }
    }
   
    
    return 0;
}

/*
5 6 666
5 5 6 8 9


*/