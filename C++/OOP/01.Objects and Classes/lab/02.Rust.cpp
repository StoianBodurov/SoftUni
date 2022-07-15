#include <iostream>

using namespace std;


class Rust
{
    private:
        char matrix[10][10];
        char result[10][10];
        int count;

    public:
        Rust(istream & istr);

    private:
        void copyMatrix();

    public:
        void makeRust();
        void printResult();

};

Rust::Rust(istream &istr)
{
    for (int r = 0; r < 10; r++){

        string el;
        istr >> el;

        for (int c = 0; c < 10; c++){

            matrix[r][c] = el[c];
            result[r][c] = el[c];
        }
    }
    istr >> count;
    

}

void Rust::copyMatrix(){
    for (int r = 0; r < 10; r++){
        for (int c = 0; c <10; c++){
            matrix[r][c] = result[r][c];
        }
    }
}

void Rust::makeRust(){
    for (int i = 0; i < count; i++){

        for (int r = 0; r < 10; r++){
            for (int c = 0; c < 10; c++){
                if (matrix[r][c] == '!'){
                    if (r - 1 >= 0 && matrix[r - 1][c] != '#'){
                        result[r - 1][c] = '!';
                    }
                    if (r + 1 < 10 && matrix[r + 1][c] != '#'){
                        result[r + 1][c] = '!';
                    }
            
                    if (c - 1 >= 0 && matrix[r][c - 1] != '#'){
                        result[r][c - 1] = '!';
                    }
                    if (c + 1 < 10 && matrix[r][c + 1] != '#'){
                        result[r][c + 1] = '!';
                    }    
                }  

            }
        }
        copyMatrix();
    }
}

void Rust::printResult(){
    for (int r = 0; r < 10; r++){
        for(int c = 0; c < 10; c++){
            cout << matrix[r][c];
        }
        cout << endl;
    }
}


int main(){
    Rust rust(cin);
    rust.makeRust();
    rust.printResult();

    return 0;
}

/*
..........
....!.....
..........
..........
..........
..........
..........
..........
..........
..........
4
*/