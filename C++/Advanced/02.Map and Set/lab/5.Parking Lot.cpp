#include <iostream>
#include <set>
#include <list>
#include <sstream>


using namespace std;


int main(){

    set<string> parkingLot;
    list<string>  orderedParking;

    while (true)
    {
        string input;
        getline(cin, input);
        stringstream ss(input);
        string command;
        string carNumber;

        getline(ss, command, ',');
        ss >> carNumber;



        if (command == "END"){
            break;
        }

        if (command  == "IN"){
            if (parkingLot.find(carNumber) == parkingLot.end()){

                parkingLot.insert(carNumber);
                orderedParking.push_back(carNumber);
            }
            

        }else if(command == "OUT"){

            auto search = parkingLot.find(carNumber);

           if (search != parkingLot.end()){

               parkingLot.erase(*search);
               orderedParking.remove(*search);
           } 
        }

    }
    if (parkingLot.size() > 0){
        for (list<string>:: iterator it = orderedParking.begin(); it != orderedParking.end(); it++){
            cout << *it << endl;
            
        }
    }else {
        cout << "Parking Lot is Empty" << endl;
    }
    
    

    return 0;
}