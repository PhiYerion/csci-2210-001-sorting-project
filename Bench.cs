using System.Diagnostics;

namespace sorting_algos;

public class BenchResult : IFormattable
{
    public AlgoTypes.Enum algo;
    public SortType initialSort;
    public int iterations;
    public long ms;

    public enum SortType
    {
        Random,
        SemiSorted
    }

    public BenchResult(AlgoTypes.Enum algo, SortType initialSort, int iterations, long ms)
    {
        this.algo = algo;
        this.initialSort = initialSort;
        this.iterations = iterations;
        this.ms = ms;
    }

    public string ToString(string? format, IFormatProvider? formatProvider)
    {
        return algo + "-" + initialSort + "-" + iterations + " took " + ms + "ms";
    }
}

public class Bench
{
    /// <summary> Bench a certain sorting algorithm </summary>
    /// <param name="sort"> The sorting algorithm to bench </param>
    /// <param name="gen"> The generator class for the type T </param>
    /// <param name="iterations"> The amount of iterations to run the sorting
    /// algorithm </param>
    public static BenchResult[] BenchSortingAlgo<T>(
            ISort<T> sort,
            RandomGenerator<T> gen,
            int iterations = 1000,
            int amt = 1000
        ) where T : IComparable<T>
    {
        var rng = new Random();
        // Warmup
        for (int i = 0; i < iterations / 3 + 10; i++)
            sort.Sort(gen.RandomList(amt, rng));

        var timer = Stopwatch.StartNew();
        for (int i = 0; i < iterations; i++)
            sort.Sort(gen.RandomList(amt, rng));
        timer.Stop();
        var randomResult = new BenchResult(
            sort.Type,
            BenchResult.SortType.Random,
            amt,
            timer.ElapsedMilliseconds);

        timer.Restart();
        for (int i = 0; i < iterations; i++)
            sort.Sort(gen.PartiallySorted(amt, rng));
        timer.Stop();
        var semiSortedResult = new BenchResult(
            sort.Type,
            BenchResult.SortType.SemiSorted,
            amt,
            timer.ElapsedMilliseconds);

        return new BenchResult[] { randomResult, semiSortedResult };
    }

    /// <summary> Bench all sorting algorithms </summary>
    /// <param name="gen"> The generator class for the type T </param>
    /// <param name="iterations"> The amount of iterations to run the sorting
    /// algorithm </param>
    public static IEnumerable<BenchResult> AllAlgos<T>(
            RandomGenerator<T> gen,
            int iterations = 100)
        where T : IComparable<T>
    {
        foreach (int amt in new int[] { 10, 100, 1000, 10000 })
        {
            foreach (var algo in AlgoTypes.Iter<T>())
            {
                var results = BenchSortingAlgo(algo, gen, iterations, amt);
                foreach (var result in results)
                    yield return result;
            }
        }
    }
}
