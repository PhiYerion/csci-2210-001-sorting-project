namespace sorting_algos;

public class Inputs
{
    public int[] randomNumbers(
            int amount = 1000,
            int min = Int32.MinValue,
            int max = Int32.MaxValue)
    {
        Random random = new Random();
        int[] numbers = new int[amount];
        for (int i = 0; i < amount; i++)
        {
            numbers[i] = random.Next(min, max);
        }
        return numbers;
    }

    public int[] partiallySortedNums(
            int amount = 1000,
            int chanceDivisor = 10,
            int min = Int32.MinValue,
            int max = Int32.MaxValue)
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
