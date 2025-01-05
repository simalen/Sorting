using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class Algorithms
    {
        // Merge Sort
        public static void MergeSort(int[] array)
        {
            if (array.Length <= 1) return;
            int mid = array.Length / 2;
            int[] left = new int[mid];
            int[] right = new int[array.Length - mid];

            Array.Copy(array, 0, left, 0, mid);
            Array.Copy(array, mid, right, 0, array.Length - mid);

            MergeSort(left);
            MergeSort(right);
            Merge(array, left, right);
        }

        private static void Merge(int[] array, int[] left, int[] right)
        {
            int i = 0, j = 0, k = 0;

            while (i < left.Length && j < right.Length)
            {
                if (left[i] <= right[j])
                    array[k++] = left[i++];
                else
                    array[k++] = right[j++];
            }

            while (i < left.Length)
                array[k++] = left[i++];
            while (j < right.Length)
                array[k++] = right[j++];
        }

        // Quick Sort
        public static void QuickSort(int[] array)
        {
            QuickSort(array, 0, array.Length-1);
        }

        public static void QuickSort(int[] array, int low, int high)
        {
            while (low < high)
            {
                int pivotIndex = Partition(array, low, high);

                if (pivotIndex - low <= high - (pivotIndex + 1))
                {
                    QuickSort(array, low, pivotIndex);
                    low = pivotIndex + 1;
                }
                else
                {
                    QuickSort(array, pivotIndex + 1, high);
                    high = pivotIndex;
                }
            }
        }

        private static int Partition(int[] array, int low, int high)
        {

            int x = array[low], i = low-1, j = high+1;

            while (true)
            {
                do
                {
                    i++;
                } while (i < high && array[i] < x);
                do
                {
                    j--;
                } while (j > low && array[j] > x);

                if (i < j)
                {
                    int tmp = array[i];
                    array[i] = array[j];
                    array[j] = tmp;
                }
                else
                {
                    return j;
                }
            }
        }

        public static void InsertionSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 1; i < n; ++i)
            {
                int key = arr[i];
                int j = i - 1;
                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }
                arr[j + 1] = key;
            }
        }

        // Heap Sort
        public static void HeapSort(int[] array)
        {
            int n = array.Length;

            for (int i = n / 2 - 1; i >= 0; i--)
                Heapify(array, n, i);

            for (int i = n - 1; i > 0; i--)
            {
                (array[0], array[i]) = (array[i], array[0]);
                Heapify(array, i, 0);
            }
        }

        private static void Heapify(int[] array, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < n && array[left] > array[largest])
                largest = left;

            if (right < n && array[right] > array[largest])
                largest = right;

            if (largest != i)
            {
                (array[i], array[largest]) = (array[largest], array[i]);
                Heapify(array, n, largest);
            }
        }
    }
}
