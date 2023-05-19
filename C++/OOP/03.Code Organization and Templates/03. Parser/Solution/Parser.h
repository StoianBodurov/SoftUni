#ifndef PARSER_H
#define PARSER_H

#include <string>
#include <istream>
#include <sstream>

template<typename T>
class Parser{
    std::istream& in;
    std::string stopLine;

    public:
    Parser(std::istream& in_, std::string stopLine_) : in(in_), stopLine(stopLine_){}

    bool readNext(T& next){
        std::string line;
        std::getline(in, line);

        if (line != stopLine){
            std::istringstream lineIn(line);
            lineIn >> next;
            return true;
        }else{
            return false;
        }
    }

};


#endif