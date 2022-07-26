#ifndef CAR_H
#define CAR_H



class Car
{
private:
    std::string sBrand;
    std::string sModel;
    int nYear;
public:
    Car(std::string sBrand, std::string sModel, int nYear);
    std::string GetBrand()const;
    std::string GetModel()const;
    int GetYear()const;
};

Car::Car(std::string sBrand, std::string sModel, int nYear): sBrand(sBrand), sModel(sModel), nYear(nYear){}

std::string Car::GetBrand()const{
    return sBrand;
}

std::string Car::GetModel()const{
    return sModel;
}

int Car::GetYear()const{
    return nYear;
}




#endif
