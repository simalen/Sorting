using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class Test
    {
        public static SortingResult Sort(string algorithmName, int[] dataset, Action<int[]> sortFunction, bool isSmallDataset, string datasetName)
        {
            int[] dataCopy = (int[])dataset.Clone(); // Copy the array to avoid modifying the original
            Stopwatch stopwatch = new Stopwatch();
            Console.WriteLine($"Testing {algorithmName} on {(isSmallDataset ? "Small Dataset" : "Large Dataset")}:");
            Console.OutputEncoding = System.Text.Encoding.UTF8; // For icons

            //Start the timer + write on console
            stopwatch.Start();
            Console.Write("- Timer started");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("▶️");
            Console.ForegroundColor = ConsoleColor.White;

            sortFunction(dataCopy); // Gets the data

            //Start the timer + write on console
            stopwatch.Stop();
            Console.Write("- Timer stopped");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("🟥");
            Console.ForegroundColor = ConsoleColor.White;

            /*
            foreach (int item in dataCopy)
            {
                Console.Write(item + " ");
            }*/
            

            Console.Write($"  {algorithmName} completed in {stopwatch.Elapsed.TotalMilliseconds} ms 🕑");
            Console.Write("\n");
            //Adds the result to the list
            SortingResult result = new SortingResult(datasetName, algorithmName, stopwatch.Elapsed.TotalMilliseconds);

            if (stopwatch.ElapsedMilliseconds > 10000.0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This operation took too long! ⏳");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine("\n");
            return result;
        }
        public static void DisplaySummaryTable(List<SortingResult> results)
        {
            Console.WriteLine("\n");
            Console.WriteLine("                  Summary Table (Fastest to Slowest) (P for parallel):");
            Console.WriteLine("         -------------------------------------------------------------");
            Console.WriteLine("                --------------------------------------------");
            Console.WriteLine("               |     Dataset     |    Algorithm    | Speed  |");
            Console.WriteLine("                --------------------------------------------");

            int count = 0;
            foreach (var result in results)
            {
                if (count == results.Count / 3)
                {
                    count = 0;
                    Console.WriteLine("              - - - - - - - - - - - - - - - - - - - - - - - - -");
                }
                Console.WriteLine($"             | {result.DatasetName,-15} | {result.AlgorithmName,-15} | {result.elapsedMilliseconds,-10} ms |");
                count++;
            }
            Console.WriteLine("               - - - - - - - - - - - - - - - - - - - - - - - - -");

            
        }
    }
}
