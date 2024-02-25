// See https://aka.ms/new-console-template for more information
using sorting_algos;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] randomNumbers(int amount, int min, int max)
        {
            Random random = new Random();
            int[] numbers = new int[amount];
            for (int i = 0; i < amount; i++)
            {
                numbers[i] = random.Next(min, max);
            }
            return numbers;
        }

        int[] partiallySortedNums(int amount, int chanceDivisor, int min, int max)
        {
            var start = randomNumbers(amount, min, max);
            Array.Sort(start);

            Random random = new Random();
            foreach (int i in start)
            {
                if (random.Next(0, chanceDivisor) == 0)
                {
                    start[i] = random.Next(min, max);
                }
            }

            return start;
        }
    }
}
