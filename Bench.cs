using System.Diagnostics;

namespace sorting_algos;

public class Bench
{
    public static long BenchSortingAlgo(
            ISort sort,
            Func<int[]> arrGen,
            int iterations = 1000)
    {
        // Warmup
        for (int i = 0; i < iterations; i++)
        {
            sort.Sort(arrGen());
        }

        var timer = Stopwatch.StartNew();
        for (int i = 0; i < iterations; i++)
        {
            sort.Sort(arrGen());
        }
        timer.Stop();

        return timer.ElapsedMilliseconds;
    }
}
