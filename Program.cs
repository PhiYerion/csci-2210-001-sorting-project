// See https://aka.ms/new-console-template for more information
using sorting_algos;

internal class Program
{
    /// <summary>Benchmarks the array from 'gen' using Bubble Sort and Merge
    /// Sort and prints the results</summary>
    ///
    /// <param name="gen">The lambda that generates the array to be sorted</param>
    /// <param name="export">Whether to export the results to a CSV file</param>
    private static void oneRun<T>(RandomGenerator<T> gen, bool export = false) where T : IComparable<T>
    {
        if (export)
            Console.WriteLine("algo,initialSort,iterations,ms");

        var numResults = Bench.AllAlgos(gen);
        foreach (BenchResult bench in numResults)
            if (export)
                Console.WriteLine(bench.algo.ToString() + ',' + bench.initialSort + ',' + bench.iterations + ',' + bench.ms);
            else
                Console.WriteLine(bench);
    }

    private static void Main(string[] args)
    {
        bool export = args.Length > 0 && args[0] == "export";

        if (!export) Console.WriteLine("\n\n\nNumbers:");
        oneRun(new RandomNumbers(), export);

        if (!export) Console.Write("\n\n\nBooks:\n");
        oneRun(new RandomBooks(), export);
    }
}
