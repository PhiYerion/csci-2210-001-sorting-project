// See https://aka.ms/new-console-template for more information
using sorting_algos;

internal class Program
{
    /// <summary>Benchmarks the array from 'gen' using Bubble Sort and Merge
    /// Sort and prints the results</summary>
    ///
    /// <param name="gen">The lambda that generates the array to be sorted</param>
    private static void bench<T>(Func<int, T[]> gen) where T : IComparable<T>
    {
        var numResults = Bench.AllAlgos(gen);
        foreach ((String testName, long ms) in numResults)
        {
            Console.WriteLine(testName + " took " + ms + "ms");
        }

        Console.WriteLine("\n\n# For Export:\n");
        foreach ((String testName, long ms) in numResults)
        {
            Console.WriteLine(testName + "," + ms);
        }
    }

    private static void Main(string[] args)
    {
        Console.WriteLine("\n\n\nRandom Numbers:");
        Thread t1 = new Thread(() => bench((int amount) => Inputs.RandomNumbers(amount)));
        t1.Start();
        Console.WriteLine("\n\n\nSemi-Sorted Numbers:");
        Thread t2 = new Thread(() => bench((int amount) => Inputs.PartiallySortedNums(amount)));
        t2.Start();

        Console.WriteLine("\n\n\nBooks:");
        Thread t3 = new Thread(() => bench((int amount) => Inputs.RandomBooks(amount)));
        t3.Start();

        t1.Join();
        t2.Join();
        t3.Join();
    }
}
