using System.Collections;
using System.Runtime.Intrinsics.X86;

namespace PerformanceResearch;

public static class LargeArrayAccess
{
    public static int Sequential(int size, int count)
    {
        //var array = new bool[size];
        var array = new int[size];
        //var array = new BitArray(size);
        var r = new Random(Environment.TickCount);
        var c = 0;
        while (true)
        {
            var pos = r.Next(size);
            var cnt = r.Next(10000);

            for (var i = 0; i < cnt; i++)
            {
                //array[pos] = !array[pos];
                array[pos]++;
                pos++;
                if (pos >= size) pos = 0;
            }

            c += cnt;
            if (++c >= count) return c;
        }
    }

    public static int Random(int size, int count)
    {
        //var array = new BitArray(size);
        var array = new int[size];
        var r = new Random(Environment.TickCount);
        var c = 0;
        while (true)
        {
            var start = r.Next(size);
            var cnt = r.Next(10000);
            var step = r.Next(100) + 1;

            var pos = start;
            for (var i = 1; i <= cnt; i++)
            {
                //array[pos] = !array[pos];
                array[pos]++;
                //pos = (pos + start) % size;
                pos += step;
                if (pos >= size) pos -= size;
            }

            c += cnt;
            if (c >= count) return c;
        }
    }
}