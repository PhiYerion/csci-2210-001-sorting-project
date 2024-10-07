namespace sorting_algos;

public abstract class RandomGenerator<T> where T : IComparable<T>
{
    public abstract T Random(Random rng);

    /// <summary> Generate a list of random numbers </summary>
    /// <param name="amt"> The amount of random numbers to generate </param>
    /// <param name="rng"> The random number generator </param>
    /// <returns> A list of random numbers </returns>
    public T[] RandomList(long amt, Random rng)
    {
        T[] vals = new T[amt];
        for (int i = 0; i < vals.Length; i++)
            vals[i] = Random(rng);
        return vals;
    }

    /// <summary> Generate a list of random numbers that are partially sorted </summary>
    /// <param name="amt"> The amount of random numbers to generate </param>
    /// <param name="rng"> The random number generator </param>
    /// <returns> A list of partially sorted random numbers </returns>
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

    /// <summary> Generate a random string </summary>
    /// <param name="length"> The length of the string </param>
    /// <param name="rng"> The random number generator </param>
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
