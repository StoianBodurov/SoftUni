#include <iostream>
#include <string>

using namespace std;


void printGrade(double grade){
    if (grade >= 2 && grade < 3){
        cout << "Fail";
    } else if( grade >= 3 && grade < 3.5){
        cout << "Poor";
    } else if(grade >= 3.5 && grade < 4.5){
        cout << "Good";
    }else if(grade >= 4.5 && grade < 5.5){
        cout << "Very good";
    }else if(grade >= 5.5){
        cout << "Excellent";
    }
}

int main()
{
    double grade;
    cin >> grade;

    printGrade(grade);

    return 0;
}