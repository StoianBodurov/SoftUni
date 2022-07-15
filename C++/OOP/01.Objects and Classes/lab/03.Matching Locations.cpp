#include <iostream>
#include <vector>
#include <regex>

using namespace std;


class Locations
{
private:
    string name;
    string latitude;
    string longitude;

public:
    Locations(string data);
    Locations();
    string getName(){
        return name;
    }

    string getLatitude(){
        return latitude;
    }

    string getLongitude(){
        return longitude;
    }
};

Locations::Locations(string data){
    vector<string> tempVector;
    string tempString = "";
    for (int i = 0; i < data.size(); i++){
        if (data[i] == ','){
            tempVector.push_back(tempString);
            tempString = "";
            continue;
        }
        tempString += data[i];
    }
    tempVector.push_back(tempString);


    name = tempVector[0];
    latitude = tempVector[1];
    longitude = tempVector[2];
}


int main(){
    vector<Locations> places;
    while (true)
    {
        string data;
        getline(cin, data);

        if (data == "."){
            break;
        }

        Locations locations(data);
        places.push_back(locations);

    }

    while (true)
    {
        string data;
        getline(cin , data);

        if (data == "."){
            break;
        }

        if (isdigit(data[data.size() - 1])){
            for (Locations l : places){
                if ((l.getLatitude() + " " + l.getLongitude()) == data){
                    cout << l.getName() << "," << l.getLatitude() << "," << l.getLongitude() << endl;
                }
            }
        }else{
            for (Locations l : places){
                if (l.getName() == data){
                    cout << l.getName() << "," << l.getLatitude() << "," << l.getLongitude() << endl;
                }
            }
        }
    }
    
    

    return 0;
}


/*
Sofia,42.70,23.33
New York,40.6976701,-74.2598732
SoftUni,42.70,23.33
.
Sofia
40.6976701 -74.2598732
42.70 23.33
.
*/