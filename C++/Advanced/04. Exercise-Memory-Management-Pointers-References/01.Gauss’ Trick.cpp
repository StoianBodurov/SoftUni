#include <iostream>
#include <sstream>
#include <vector>


using namespace std;

void sums(vector<int>& num){
     for (int i = 0; i <= num.size() / 2; i++){
        num[i] += num[num.size() - 1];
        num.pop_back();
    }
}

void readInput(vector<int>& num){
    string data;
    getline(cin, data);

    stringstream ss(data);

    int n;
    while (ss >> n)
    {
        num.push_back(n);
    }

}

void printList(vector<int>& num){
    for (int n:num){
        cout << n << " ";
    }
    cout << endl;
    
}

int main(){

    
    vector<int> numbers;
    readInput(numbers);

    if (numbers.size() == 1){
        cout << numbers[0]<< endl;
        return 0;
    }

    sums(numbers);
    printList(numbers);

    return 0;
}