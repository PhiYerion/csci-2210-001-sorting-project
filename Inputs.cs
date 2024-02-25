namespace sorting_algos;

public class Inputs
{
    public static int[] randomNumbers(
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

    public static int[] PartiallySortedNums(
            int amount = 1000,
            int chanceDivisor = 10,
            int min = Int32.MinValue,
            int max = Int32.MaxValue)
    {
        var start = randomNumbers(amount, min, max);
        Array.Sort(start);

        Random random = new Random();
        for (int i = 0; i < amount; i++)
        {
            if (random.Next(0, chanceDivisor) == 0)
            {
                start[i] = random.Next(min, max);
            }
        }

        return start;
    }
}
