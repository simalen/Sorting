using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public enum DatasetType
    {
        RANDOM, REVERSED, ORDERED
    }

    public class Dataset
    {
        public string Name { get; } // T.ex. "Random", "Sorted", etc.
        public int[] Data { get; set; }  //the array

        public Dataset(int size, DatasetType type) {
            Data = new int[size];
            Random rnd = new Random();

            switch (type)
            {
                case DatasetType.RANDOM:
                    for (int i = 0; i < size; i++)
                    {
                        Data[i] = rnd.Next(1, size);
                    }
                    Name = "Random";
                    break;
                case DatasetType.REVERSED:
                    int num = size - 1;
                    for (int i = 0; i < size; i++)
                    {
                        Data[i] = num;
                        num--;
                    }
                    Name = "Reversed";
                    break;
                case DatasetType.ORDERED:
                    for (int i = 0; i < size; i++)
                    {
                        Data[i] = i;
                    }
                    Name = "Ordered";
                    break;
            }
        }
    }
}
