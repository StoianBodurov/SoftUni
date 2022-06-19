#include <iostream>
#include <sstream>
#include <queue>
#include <vector>

using namespace std;

int main(){

    int numberCommands;
    cin >> numberCommands;
    cin.ignore();

    queue<string> pepiCustumer;
    vector<int> pepiCustumerTime;
    queue<string> mimiCustumar;
    vector<int> mimiCustumerTime;

    for (int i = 0; i < numberCommands; i++){
        string data;
        getline(cin, data);
        string custumer;
        string worker;
        int time;

        stringstream ss(data);
        ss >> worker;
        ss >> custumer;
        ss >> time;

        if (worker == "Mimi"){
            mimiCustumar.push(custumer);
            mimiCustumerTime.push_back(time);
        }else {
            pepiCustumer.push(custumer);
            pepiCustumerTime.push_back(time);
        }

    }
    int minutes;
    cin >> minutes;

    for (int i = 0; i < minutes; i++){
        if (!pepiCustumer.empty()){
            cout << "Pepi " << "processing "<< pepiCustumer.front() << endl;
            if (pepiCustumerTime[0] - 1 == 0 ){
                pepiCustumer.pop();
                pepiCustumerTime.erase(pepiCustumerTime.begin());
            }else {
                pepiCustumerTime[0]--;
            }

        }else {
            cout << "Pepi " << "Idle" << endl;
        }

        if (!mimiCustumar.empty()){
            cout << "Mimi " << "processing " << mimiCustumar.front() << endl;
            if (mimiCustumerTime[0] - 1 == 0){
                mimiCustumar.pop();
                mimiCustumerTime.erase(mimiCustumerTime.begin());
            }else{
                mimiCustumerTime[0]--;
            }
        }else {
            cout << "Mimi " << "Idle" << endl;
        }
    }


    return 0;
}