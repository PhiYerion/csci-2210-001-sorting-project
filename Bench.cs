using System.Diagnostics;

namespace sorting_algos;

public class Bench
{
    /// <summary> Bench a certain sorting algorithm </summary>
    /// <param name="sort"> The sorting algorithm to bench </param>
    /// <param name="arrGen"> A function that generates an array of type T </param>
    /// <param name="iterations"> The amount of iterations to run the sorting
    /// algorithm </param>
    public static long BenchSortingAlgo<T>(
            ISort<T> sort,
            Func<T[]> arrGen,
            int iterations = 1000
        ) where T : IComparable<T>
    {
        // Warmup (let's hope this doesn't effect GC after...)
        for (int i = 0; i < iterations / 3 + 10; i++)
            sort.Sort(arrGen());

        var timer = Stopwatch.StartNew();
        for (int i = 0; i < iterations; i++)
            sort.Sort(arrGen());
        timer.Stop();

        return timer.ElapsedMilliseconds;
    }

    /// <summary> Bench all sorting algorithms </summary>
    /// <param name="gen"> A function that generates an array of type T </param>
    /// <param name="iterations"> The amount of iterations to run the sorting
    /// algorithm </param>
    public static List<(String, long)> AllAlgos<T>(
            Func<int, T[]> gen,
            string name = "",
            int iterations = 20
        ) where T : IComparable<T>
    {
        var results = new List<(String, long)>();

        // Bench Merge and Bubble algorithms for semi sorted and random arrays
        // of different sizes (amount is the size)
        foreach (int amount in new int[] { 10, 100, 1000, 2000, 3000, 4000, 5000, 10000 })
        {
            var endString = "-" + name + "-" + typeof(T) + "-" + amount + "-" + iterations;

            Thread t1 = new Thread(() =>
            {
                long result = BenchSortingAlgo(
                    new BubbleSort<T>(),
                    () => gen(amount),
                    iterations);
                Console.WriteLine("BubbleSort" + endString + "," + result);
            });

            Thread t2 = new Thread(() =>
            {
                long result = BenchSortingAlgo(
                    new MergeSort<T>(),
                    () => gen(amount),
                    iterations);
                Console.WriteLine("MergeSort" + endString + "," + result);
            });
        }

        return results;
    }
}
