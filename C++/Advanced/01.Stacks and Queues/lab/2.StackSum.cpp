#include <iostream>
#include <stack>
#include <string>
#include <sstream>

using namespace std;

int main(){

    string data;
    getline(cin, data);

    stack<int> numbers;
    stringstream ss(data);

    string n;
    while (ss >> n)
    {
        numbers.push(stoi(n));
    }
    

    while ( true )
    {
        string token;
        getline(cin, token);
        stringstream s(token);
        string command;
        s >> command;

        for (int i = 0; i < command.length(); i++)
        {
            command[i] = tolower(command[i]);
        }

        if (command == "end"){
            break;
        }


        if (command == "add"){
            string n;
            while (s >> n)
            {
                numbers.push(stoi(n));
            }
            
        }else if(command == "remove"){
            int countToRemove;
            s >> countToRemove;

            if (numbers.size() < countToRemove){
                continue;
            }

            for (int i = 0; i < countToRemove; i++){
                numbers.pop();
            }
        }
    }
    int sum = 0;

    while (!numbers.empty())
    {
        sum += numbers.top();
        numbers.pop();
    }
    cout << "Sum: "<< sum << endl;
    return 0;
}