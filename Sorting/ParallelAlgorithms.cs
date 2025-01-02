using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class ParallelAlgorithms
    {
        // Insertion sort
        public static void InsertionSort(int[] array)
        {
            int[] even = new int[array.Length], odd = new int[array.Length];
            int n_even = 0, n_odd = 0;

            foreach (int i in array)
            {
                if((i & 1) == 0)
                {
                    even[n_even] = i;
                    n_even++;
                }
                else
                {
                    odd[n_odd] = i;
                    n_odd++;
                }
            }
            Array.Resize(ref even, n_even);
            Array.Resize(ref odd, n_odd);

            Thread even_thread = new Thread(() => Algorithms.InsertionSort(even));
            Thread odd_thread = new Thread(() => Algorithms.InsertionSort(odd));

            even_thread.Start();
            odd_thread.Start();

            even_thread.Join();
            odd_thread.Join();

            int[] result = OddEvenMerge(even, odd, n_even, n_odd);

            for(int i = 0; i < array.Length; i++)
            {
                array[i] = result[i];
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
                Thread left_thread = new Thread(() => MergeSort(left, depth + 1));
                Thread right_thread = new Thread(() => MergeSort(right, depth + 1));

                left_thread.Start();
                right_thread.Start();

                left_thread.Join();
                right_thread.Join();

                Thread merge = new Thread(() => Merge(array, left, right));
                merge.Start();
            }
            else
            {
                MergeSort(left, depth + 1);
                MergeSort(right, depth + 1);

                Merge(array, left, right);
            }
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

        public static void QuickSort(int[] array, int low, int high)
        {

        }

        // Only sorted arrays
        public static int[] OddEvenMerge(int[] even, int[] odd, int n_even, int n_odd)
        {
            int length = n_even + n_odd, even_index = 0, odd_index = 0;
            int[] result = new int[length];

            Console.WriteLine();
            Console.WriteLine();

            for (int i = 0; i < length; i++)
            {
                if (odd_index == n_odd)
                {
                    result[i] = even[even_index];
                    continue;
                }
                else if(even_index == n_even)
                {
                    result[i] = odd[odd_index];
                    continue;
                }


                if(odd[odd_index] < even[even_index])
                {
                    result[i] = odd[odd_index];
                    odd_index++;
                }
                else
                {
                    
                    result[i] = even[even_index];
                    even_index++;
                }
            }

            return result;
        }
    }
}
