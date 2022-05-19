#include <iostream>
#include <queue>
#include <istream>

using namespace std;

int main(){

    int countCarCanPass;
    cin >> countCarCanPass;
    queue<string> cars;

    string command;
    getline(cin, command);

    int numberPassedCars = 0;

    while (command != "end")
    {
        cout << command;
        if (command == "green"){
            for (int i = 0; i < countCarCanPass; i++){
                if (cars.empty()){
                    break;
                }

                cout << cars.front() << " passed!" << endl;
                cars.pop();
                numberPassedCars++;
            }
        }else if (command != ""){
            cars.push(command);
        }
        getline(cin, command);
    }
    
    cout << numberPassedCars << " cars passed the crossroads." << endl;
    return 0;
}


/*
4
Hummer H2
Audi
Lada
Tesla
Renault
Trabant
Mercedes
MAN Truck
green
green
Tesla
Renault
Trabant
end
*/