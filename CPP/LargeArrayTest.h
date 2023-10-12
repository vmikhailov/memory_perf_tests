//
// Created by Viacheslav Mikhailov on 12/10/2023.
//

#ifndef PEFORMANCERESEARCHCPP_LARGEARRAYTEST_H
#define PEFORMANCERESEARCHCPP_LARGEARRAYTEST_H
#include <random>

class LargeArrayTest {
private:
    std::mt19937 mt;

public:
    LargeArrayTest();
    int Sequential(int size, int count);
    int Random(int size, int count);
};


#endif //PEFORMANCERESEARCHCPP_LARGEARRAYTEST_H
