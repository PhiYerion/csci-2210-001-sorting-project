namespace sorting_algos;

public abstract class RandomGenerator<T> where T : IComparable<T>
{
    public abstract T Random(Random rng);

    public T[] RandomList(long amt, Random rng)
    {
        T[] vals = new T[amt];
        for (int i = 0; i < vals.Length; i++)
            vals[i] = Random(rng);
        return vals;
    }

    public T[] PartiallySorted(long amt, Random rng)
    {
        T[] numbers = RandomList(amt, rng);
        Array.Sort(numbers);

        for (int i = 0; i < numbers.Length; i++)
            if (rng.Next(0, 10) == 0)
                numbers[i] = Random(rng);

        return numbers;
    }
}

public class RandomNumbers : RandomGenerator<int>
{
    public override int Random(Random rng)
    {
        return rng.Next(int.MinValue, int.MaxValue);
    }
}

public class RandomBooks : RandomGenerator<Book>
{
    public override Book Random(Random rng)
    {
        return new Book(
            randomString(10, rng),
            randomString(10, rng),
            randomString(30, rng),
            randomString(4, rng, '0', '9') + "-"
                + randomString(2, rng, '0', '9') + "-"
                + randomString(2, rng, '0', '9')
            );
    }

    private static string randomString(int length, Random rng, char start = 'A', char end = 'z')
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
