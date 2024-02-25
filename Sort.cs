namespace sorting_algos;

public interface ISort
{
    public void Sort<T>(T[] arr) where T : IComparable<T>;
}

public class BubbleSort : ISort
{
    public void Sort<T>(T[] arr) where T : IComparable<T>
    {
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = 0; j < arr.Length - 1; j++)
            {
                if (arr[j].CompareTo(arr[j + 1]) > 0)
                {
                    T temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }
}

public class MergeSort : ISort
{
    public void mergeArray<T>(T[] arr, T[] left, T[] right) where T : IComparable<T>
    {
        int array_index = 0, left_index = 0, right_index = 0;

        while (left_index < left.Length && right_index < right.Length)
        {
            if (left[left_index].CompareTo(right[right_index]) < 0)
            {
                arr[array_index++] = left[left_index++];
            }
            else
            {
                arr[array_index++] = right[right_index++];
            }
        }

        while (left_index < left.Length)
        {
            arr[array_index++] = left[left_index++];
        }

        while (right_index < right.Length)
        {
            arr[array_index++] = right[right_index++];
        }
    }

    public void Sort<T>(T[] arr) where T : IComparable<T>
    {
        if (arr.Length <= 1) return;

        T[] left = new T[arr.Length / 2];
        T[] right = new T[arr.Length - arr.Length / 2];

        Array.Copy(arr, 0, left, 0, arr.Length / 2);
        Array.Copy(arr, arr.Length / 2, right, 0, right.Length);

        Sort(left);
        Sort(right);

        mergeArray(arr, left, right);
    }
}
