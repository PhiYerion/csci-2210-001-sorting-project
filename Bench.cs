using System.Diagnostics;

namespace sorting_algos;

public class Bench
{
    public static long BenchSortingAlgo<T>(
            ISort<T> sort,
            Func<T[]> arrGen,
            int iterations = 1000
        ) where T : IComparable<T>
    {
        // Warmup
        for (int i = 0; i < iterations / 3 + 10; i++)
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

    public static List<(String, long)> AllAlgos<T>(
            Func<T[]> gen, 
            int iterations = 100) 
        where T : IComparable<T>
    {
        var results = new List<(String, long)>();

        foreach (int amount in new int[] { 10, 100, 1000, 10000 })
        {
            var endString = "-" + amount + "-" + iterations;

            Console.WriteLine("BubbleSort-Random" + endString);
            results.Add(("BubbleSort-Random" + endString,
                        BenchSortingAlgo(
                            new BubbleSort<T>(),
                            gen,
                            iterations)));

            Console.WriteLine("MergeSort-Random" + endString);
            results.Add(("MergeSort-Random" + endString,
                        BenchSortingAlgo(
                            new MergeSort<T>(),
                            gen,
                            iterations)));

            Console.WriteLine("BubbleSort-SemiSorted" + endString);
            results.Add(("BubbleSort-SemiSorted" + endString,
                        BenchSortingAlgo(
                            new BubbleSort<T>(),
                            gen,
                            iterations)));

            Console.WriteLine("MergeSort-SemiSorted" + endString);
            results.Add(("MergeSort-SemiSorted" + endString,
                        BenchSortingAlgo(
                            new MergeSort<T>(),
                            gen,
                            iterations)));
        }

        return results;
    }
}
