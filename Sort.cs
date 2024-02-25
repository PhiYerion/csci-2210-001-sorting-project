namespace sorting_algos;

public interface ISort<T> where T : IComparable<T>
{
    void Sort(T[] arr);
}

public class BubbleSort<T> : ISort<T> where T : IComparable<T>
{
    public void Sort(T[] arr)
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

public class MergeSort<T> : ISort<T> where T : IComparable<T>
{
    public void mergeArray(T[] arr, T[] left, T[] right)
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

    public void Sort(T[] arr)
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
