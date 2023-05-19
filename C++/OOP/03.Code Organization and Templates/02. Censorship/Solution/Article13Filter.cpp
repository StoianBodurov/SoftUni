#include <vector>
#include <string>


#include "Article13Filter.h"


Article13Filter::Article13Filter(std::set<std::string> copyrighted) : copyrighted(copyrighted){};
bool Article13Filter::blockIfCopyrighted(std::string s){
		std::set<std::string>::iterator it;
		it = copyrighted.find(s);
		if (it != copyrighted.end()){
			blocked.push_back(s);
			return true;
		}
		return false;
};
bool Article13Filter::isCopyrighted(std::string s){
    return 	copyrighted.find(s) != copyrighted.end();

};
std::vector<std::string> Article13Filter::getBlocked(){
    return std::vector<std::string> (blocked.begin(), blocked.end());
    };
