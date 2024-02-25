// See https://aka.ms/new-console-template for more information
using sorting_algos;

internal class Program
{
    private static void oneRun<T>(Func<T[]> gen) where T : IComparable<T>
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
        Console.WriteLine("\n\n\nNumbers:");
        oneRun(() => Inputs.randomNumbers());
        Console.Write("\n\n\nBooks:");
        oneRun(() => Inputs.randomBooks());
    }
}
