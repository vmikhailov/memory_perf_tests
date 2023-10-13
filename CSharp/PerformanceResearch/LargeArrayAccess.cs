using System.Collections;
using System.Runtime.Intrinsics.X86;

namespace PerformanceResearch;

public class LargeArrayAccess
{
    private readonly int _count;
    private readonly Random _random;
    private readonly int[] _shifts;
    private readonly int[] _steps;
    private readonly int[] _positions;

    public LargeArrayAccess(int count)
    {
        _count = count;
        _random = new Random(Environment.TickCount);
        _shifts = Enumerable.Range(0, _count).Select(x => _random.Next(10000)).ToArray();
        _steps = Enumerable.Range(0, _count).Select(x => _random.Next(100) + 1).ToArray();
        _positions = Enumerable.Range(0, _count).Select(x => _random.Next(1_000_000_000)).ToArray();
    }
    
    public int Sequential(int size)
    {
        //var array = new bool[size];
        var array = new int[size];
        //var array = new BitArray(size);
      
        var c = 0;
        while (true)
        {
            var pos = _positions[c] % size;
            var cnt = _shifts[c];

            for (var i = 0; i < cnt; i++)
            {
                //array[pos] = !array[pos];
                array[pos]++;
                if (++pos >= size) pos = 0;
            }

            c += cnt;
            if (++c >= _count) return c;
        }
    }

    public int Random(int size)
    {
        //var array = new BitArray(size);
        var array = new int[size];
        var c = 0;
        while (true)
        {
            var pos = _positions[c] % size;
            var cnt = _shifts[c];
            var step = _steps[c];

            for (var i = 1; i <= cnt; i++)
            {
                //array[pos] = !array[pos];
                array[pos]++;
                //pos = (pos + start) % size;
                pos += step;
                if (pos >= size) pos -= size;
            }

            c += cnt;
            if (c >= _count) return c;
        }
    }
}