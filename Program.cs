// See https://aka.ms/new-console-template for more information
using sorting_algos;

internal class Program
{
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
