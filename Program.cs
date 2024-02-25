// See https://aka.ms/new-console-template for more information
using sorting_algos;

internal class Program
{
    private static void Main(string[] args)
    {
        var results = Bench.AllAlgos();
        foreach ((String testName, long ms) in results)
        {
            Console.WriteLine(testName + " took " + ms + "ms");
        }

        Console.WriteLine("\n\n# For Export:\n");
        foreach ((String testName, long ms) in results)
        {
            Console.WriteLine(testName + "," + ms);
        }
    }
}
