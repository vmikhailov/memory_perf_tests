//
// Created by Viacheslav Mikhailov on 12/10/2023.
//

#include <cstdlib>
#include "LargeArrayTest.h"
#include <array>
#include <iostream>
#include <random>

using namespace std;

LargeArrayTest::LargeArrayTest() {
}

int LargeArrayTest::Sequential(int size, int count) {
    //std::vector<int> array;
    //array.reserve(size);
    int *array = new int[size];
    std::uniform_real_distribution<double> rndPosition(0, size);
    std::uniform_real_distribution<double> rndSize(1.0, 10000);

    int c = 0;
    while (true) {
        int pos = rndPosition(mt);
        int cnt = rndSize(mt);

        for (int i = 0; i < cnt; i++) {
            array[pos]++;
            pos++;
            if (pos >= size) pos = 0;
        }

        c += cnt;
        if (++c >= count) {
            delete[] array;
            return c;
        }
    }
}

int LargeArrayTest::Random(int size, int count){
    //std::vector<int> array;
    //array.reserve(size);
    int *array = new int[size];
    std::uniform_real_distribution<double> rndStart(0, size);
    std::uniform_real_distribution<double> rndSize(1.0, 10000);
    std::uniform_real_distribution<double> rndStep(1.0, 100);

    int c = 0;

    while (true)
    {
        int start = rndStart(mt);
        int cnt = rndSize(mt);
        int step = rndStep(mt);

        int pos = start;
        for (int i = 1; i <= cnt; i++)
        {
            array[pos]++;
            pos += step;
            if (pos >= size) pos -= size;
        }

        c += cnt;
        if (c >= count) {
            delete[] array;
            return c;
        }
    }
}