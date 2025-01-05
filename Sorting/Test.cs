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
        public static void Sort(SortingResult result, int[] dataset, Action<int[]> sortFunction, string datasetName)
        {
            int[] dataCopy = (int[])dataset.Clone(); // Copy the array to avoid modifying the original
            Stopwatch stopwatch = new Stopwatch();
            Console.WriteLine($"Testing {result.AlgorithmName} on dataset of size ({dataset.Length}):");
            Console.OutputEncoding = System.Text.Encoding.UTF8; // For icons

            //Start the timer + write on console
            stopwatch.Start();
            Console.Write("- Timer started");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("▶️");
            Console.ForegroundColor = ConsoleColor.White;

            // Ignorera
            try
            {
                sortFunction(dataCopy);
            }
            catch(Exception) 
            { 
                Console.WriteLine("Sort resulted in a StackOverflow exception..");
            }

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
            }
            */

            Console.Write($"  {result.AlgorithmName} completed in {stopwatch.Elapsed.TotalMilliseconds} ms 🕑");
            Console.Write("\n");
            //Adds the result to the list
            result.ElapsedMilliSeconds.Add(stopwatch.Elapsed.TotalMilliseconds);

            if (stopwatch.ElapsedMilliseconds > 10000.0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This operation took too long! ⏳");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine("\n");

        }
        public static void DisplaySummaryTable(List<ExportResult> export)
        {
            Console.WriteLine("\n");
            Console.WriteLine("                Summary Table (Fastest to Slowest) (P for parallel):");
            Console.WriteLine("            -------------------------------------------------------------");
            Console.WriteLine("                ---------------------------------------------------");
            Console.WriteLine("               |     Dataset     |    Algorithm    |    Speed(Avg)  |");
            Console.WriteLine("                ---------------------------------------------------");

            foreach (var result in export)
            {
                Console.WriteLine("               - - - - - - - - - - - - - - - - - - - - - - - - -");
                foreach (var item in result.Results)
                {
                    double avg = item.ElapsedMilliSeconds.Sum();
                    Console.WriteLine($"             | {result.Name,-15} | {item.AlgorithmName,-18} | {avg.ToString("#.###"),-10} ms |");
                }
                Console.WriteLine("               - - - - - - - - - - - - - - - - - - - - - - - - -");
            }
        }
    }
}
