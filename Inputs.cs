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

    public static Book[] randomBooks(int amount = 1000)
    {
        Random random = new Random();
        var books = new Book[amount];
        for (int i = 0; i < amount; i++)
        {
            books[i] = new Book(
                    randomString(10),
                    randomString(10),
                    randomString(30),
                    randomString(4, '0', '9') + "-" 
                        + randomString(2, '0', '9') + "-" 
                        + randomString(2, '0', '9')
                    );
        }
        return books;
    }

    private static string randomString(int length, char start = 'A', char end = 'z')
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
