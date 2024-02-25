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

    public static List<(String, long)> AllAlgos(int iterations = 100)
    {
        var results = new List<(String, long)>();

        foreach (int amount in new int[] { 10, 100, 1000, 10000 })
        {
            var endString = "-" + amount + "-" + iterations;

            Console.WriteLine("BubbleSort-Random" + endString);
            results.Add(("BubbleSort-Random" + endString,
                        BenchSortingAlgo(
                            new BubbleSort(),
                            () => Inputs.randomNumbers(amount),
                            iterations)));

            Console.WriteLine("MergeSort-Random" + endString);
            results.Add(("MergeSort-Random" + endString,
                        BenchSortingAlgo(
                            new MergeSort(),
                            () => Inputs.randomNumbers(amount),
                            iterations)));

            Console.WriteLine("BubbleSort-SemiSorted" + endString);
            results.Add(("BubbleSort-SemiSorted" + endString,
                        BenchSortingAlgo(
                            new BubbleSort(),
                            () => Inputs.PartiallySortedNums(amount),
                            iterations)));

            Console.WriteLine("MergeSort-SemiSorted" + endString);
            results.Add(("MergeSort-SemiSorted" + endString,
                        BenchSortingAlgo(
                            new MergeSort(),
                            () => Inputs.PartiallySortedNums(),
                            iterations)));
        }

        return results;
    }
}
