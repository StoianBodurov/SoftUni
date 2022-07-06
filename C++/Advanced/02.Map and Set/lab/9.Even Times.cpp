#include <iostream>
#include <map>

using namespace std;


int main(){

    int n;
    cin >> n;

    map<int, int> numbers;

    for (int i = 0; i < n; i++){
        int num;
        cin >> num;

        numbers[num]++;
    }

    for (map<int, int>::iterator it = numbers.begin(); it != numbers.end(); it++){
        int value = it -> second;

        if (value % 2 == 0){
            cout << it -> first << endl;
            break;
        }
    }    
    return 0;
}