using System.Collections;
using System.Runtime.Intrinsics.X86;

namespace PerformanceResearch;

public class LargeArrayAccess
{
    private readonly Random _random;

    public LargeArrayAccess()
    {
        _random = new Random(Environment.TickCount);
    }
    
    public int Sequential(int size, int count)
    {
        //var array = new bool[size];
        var array = new int[size];
        //var array = new BitArray(size);
      
        var c = 0;
        while (true)
        {
            var pos = _random.Next(size);
            var cnt = _random.Next(10000);

            for (var i = 0; i < cnt; i++)
            {
                //array[pos] = !array[pos];
                array[pos]++;
                if (++pos >= size) pos = 0;
            }

            c += cnt;
            if (++c >= count) return c;
        }
    }

    public int Random(int size, int count)
    {
        //var array = new BitArray(size);
        var array = new int[size];
        var c = 0;
        while (true)
        {
            var start = _random.Next(size);
            var cnt = _random.Next(10000);
            var step = _random.Next(100) + 1;

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