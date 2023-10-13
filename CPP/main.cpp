#include <iostream>
#include "LargeArrayTest.h"
#include <chrono>
using namespace std;
using namespace std::chrono;

int main() {
    int dataSize = 100000;
    int dataSizeMax = 1000000000;
    int testsCount = 1000000;
    int steps = 80;
    double mul = 1.025;
    int step = 0;
    LargeArrayTest g;

    while(dataSize < dataSizeMax) {
        step++;
        int rpt = 100;
        double sum_seq = 0;
        double sum_rnd = 0;
        int cnt = 0;

        while(--rpt >= 0) {
            auto start = high_resolution_clock::now();
            int actualTestsCount = g.Sequential(dataSize, testsCount);
            auto stop = high_resolution_clock::now();
            sum_seq += duration_cast<microseconds>(stop - start).count() * 1.0 * testsCount / actualTestsCount;

            start = high_resolution_clock::now();
            actualTestsCount = g.Random(dataSize, testsCount);
            stop = high_resolution_clock::now();
            sum_rnd += duration_cast<microseconds>(stop - start).count() * 1.0 * testsCount / actualTestsCount;

            cnt++;
        }

        cout << step << " " << dataSize << " " << round(sum_seq/cnt) << " " << round(sum_rnd/cnt) << endl;

        dataSize = (int)(dataSize * mul);
    }


    return 0;
}
