#ifndef PRINT_UTILS_H
#define PRINT_UTILS_H

#include <vector>

template<typename T>
void printVector(std::vector<T> v){
    for (T& element : v){
        std::cout << element << " ";
    }
}

#endif