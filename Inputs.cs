namespace sorting_algos;

public class Inputs
{
    /// <param name="amount">The amount of random numbers to generate</param>
    /// <param name="min">The minimum value of the random numbers</param>
    /// <param name="max">The maximum value of the random numbers</param>
    public static int[] RandomNumbers(
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

    /// <param name="amount">The amount of random numbers to generate</param>
    /// <param name="chanceDivisor">For each number, there will be a
    /// 1/chanceDivisor chance of it not being sorted</param>
    /// <param name="min">The minimum value of the random numbers</param>
    /// <param name="max">The maximum value of the random numbers</param>
    public static int[] PartiallySortedNums(
            int amount = 1000,
            int chanceDivisor = 10,
            int min = Int32.MinValue,
            int max = Int32.MaxValue)
    {
        var start = RandomNumbers(amount, min, max);
        Array.Sort(start);

        Random random = new Random();
        for (int i = 0; i < amount; i++)
            // 1 in chanceDivisor chance of making the number random
            if (random.Next(1, chanceDivisor) == 0)
                start[i] = random.Next(min, max);

        return start;
    }

    /// <param name="amount">The amount of random books to generate</param>
    public static Book[] RandomBooks(int amount = 1000)
    {
        Random random = new Random();
        var books = new Book[amount];
        for (int i = 0; i < amount; i++)
        {
            books[i] = new Book(
                    RandomString(10),
                    RandomString(10),
                    RandomString(30),
                    RandomString(4, '0', '9') + "-"
                        + RandomString(2, '0', '9') + "-"
                        + RandomString(2, '0', '9')
                    );
        }
        return books;
    }

    /// <param name="length">The length of the random string</param>
    private static string RandomString(int length, char start = 'A', char end = 'z')
    {
        Random random = new Random();
        String str = "";

        for (int i = 0; i < length; i++)
        {
            char c = (char)random.Next(start, end);
            str += c;
        }

        return str;
    }
}
