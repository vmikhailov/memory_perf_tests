// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using PerformanceResearch;

var sw = new Stopwatch();
var dataSize = 100_000;
var dataSizeMax = 1_000_000_000;
var testsCount = 1000000;
//var steps = 80;
var mul = 1.025d;
var step = 0;
var g = new LargeArrayAccess(testsCount);

while (dataSize < dataSizeMax)
{
    step++;
    var sum_seq = 0d;
    var sum_rnd = 0d;
    var cnt = 0;
    var rpt = 50;
    var v = 0d;
   
    while (--rpt >= 0)
    {
        sw.Restart();
        v = g.Sequential(dataSize);
        sw.Stop();
        sum_seq += (sw.Elapsed.TotalMicroseconds) * testsCount / v;

        sw.Restart();
        v = g.Random(dataSize);
        sw.Stop();
        sum_rnd += (sw.Elapsed.TotalMicroseconds) * testsCount / v;

        cnt++;
        //Console.WriteLine($"{sw.Elapsed.TotalMicroseconds} {sum/cnt:F1}");
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
    }

    Console.WriteLine($"{step} {dataSize} {sum_seq / cnt:F1} {sum_rnd / cnt:F1}");

    dataSize = (int)(dataSize * mul);
}