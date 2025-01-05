using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Sorting
{
    public class ParallelAlgorithms
    {
        public static int CalculateEfficiency(int value)
        {
            return Convert.ToInt32(Math.Log(value));
        }

        public static void InsertionSort(int[] array)
        {
            InsertionSort(array, 0, CalculateEfficiency(array.Length));
        }

        public static void InsertionSort(int[] array, int depth, int depth_max)
        {
            if (array.Length <= 1) return;
            int mid = array.Length / 2;
            int[] left = new int[mid];
            int[] right = new int[array.Length - mid];

            Array.Copy(array, 0, left, 0, mid);
            Array.Copy(array, mid, right, 0, array.Length - mid);

            if (depth < depth_max)
            {
                Parallel.Invoke(
                    () => InsertionSort(left, depth + 1, depth_max),
                    () => InsertionSort(right, depth + 1, depth_max)
                );

            }
            else
            {
                Algorithms.InsertionSort(array);
            }
        }

        public static void MergeSort(int[] array)
        {
            MergeSort(array, 0);
        }

        
        public static void MergeSort(int[] array, int depth)
        {
            if (array.Length <= 1) return;
            int mid = array.Length / 2;
            int[] left = new int[mid];
            int[] right = new int[array.Length - mid];

            Array.Copy(array, 0, left, 0, mid);
            Array.Copy(array, mid, right, 0, array.Length - mid);

            // Bästa performance ~(2-4 depth)
            if (depth < 3)
            {
                Parallel.Invoke(
                    () => MergeSort(left, depth + 1),
                    () => MergeSort(right, depth + 1)
                );
            }
            else
            {
                MergeSort(left, depth + 1);
                MergeSort(right, depth + 1);                
            }
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

        /*
        public static void QuickSort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1, 0);
        }

        static void QuickSort(int[] arr, int left, int right, int depth)
        {
            if (left < right)
            {
                int pivotIndex = Partition(arr, left, right);
                if(depth < 12)
                {
                    Parallel.Invoke(
                    () => QuickSort(arr, left, pivotIndex - 1, depth + 1),
                    () => QuickSort(arr, pivotIndex + 1, right, depth + 1)
                );
                }
                else
                {
                    QuickSort(arr, left, pivotIndex - 1, depth + 1);
                    QuickSort(arr, pivotIndex + 1, right, depth + 1);
                }
            }
        }

        static int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[right];
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    Swap(arr, i, j);
                }
            }

            Swap(arr, i + 1, right);
            return i + 1;
        }
        

        static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
        */
        public static void QuickSort(int[] array)
        {
            QuickSort(array, 0, CalculateEfficiency(array.Length));
        }

        public static void QuickSort(int[] array, int depth, int depth_max)
        {
            if (array.Length <= 1) return;
            int mid = array.Length / 2;
            int[] left = new int[mid];
            int[] right = new int[array.Length - mid];

            Array.Copy(array, 0, left, 0, mid);
            Array.Copy(array, mid, right, 0, array.Length - mid);

            if (depth < 12)
            {
                Parallel.Invoke(
                    () => QuickSort(left, depth + 1, depth_max),
                    () => QuickSort(right, depth + 1, depth_max)
                );

            }
            else
            {
                Algorithms.QuickSort(array);
            }
        }

        public static void HeapSort(int[] array)
        {
            HeapSort(array, 0, CalculateEfficiency(array.Length));
        }

        public static void HeapSort(int[] array, int depth, int depth_max)
        {
            if (array.Length <= 1) return;
            int mid = array.Length / 2;
            int[] left = new int[mid];
            int[] right = new int[array.Length - mid];

            Array.Copy(array, 0, left, 0, mid);
            Array.Copy(array, mid, right, 0, array.Length - mid);

            if (depth < 12)
            {
                Parallel.Invoke(
                    () => HeapSort(left, depth + 1, depth_max),
                    () => HeapSort(right, depth + 1, depth_max)
                );

            }
            else
            {
                Algorithms.HeapSort(array);
            }
        }
    }
}
