// See https://aka.ms/new-console-template for more information
using sorting_algos;

internal class Program
{
    /// <summary>Benchmarks the array from 'gen' using Bubble Sort and Merge
    /// Sort and prints the results</summary>
    ///
    /// <param name="gen">The lambda that generates the array to be sorted</param>
    private static void bench<T>(Func<int, T[]> gen, string name = "") where T : IComparable<T>
    {
        var numResults = Bench.AllAlgos(gen, name, 20);

        Console.WriteLine("\n\n# Results for " + name + ":\n");
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
        Thread t1 = new Thread(() => bench((int amount) => Inputs.RandomNumbers(amount), "RandomNums"));
        t1.Start();

        Thread t2 = new Thread(() => bench((int amount) => Inputs.PartiallySortedNums(amount), "PartiallySortedNums"));
        t2.Start();

        Thread t3 = new Thread(() => bench((int amount) => Inputs.RandomBooks(amount), "RandomBooks"));
        t3.Start();

        t1.Join();
        t2.Join();
        t3.Join();
    }
}
