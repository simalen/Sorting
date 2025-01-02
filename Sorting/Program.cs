using Sorting;
using System.Data;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.Json;

class Program
{   
    static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.White;

        List<Dataset> datasets = new List<Dataset>();
        
        Dataset random = new Dataset(50000, DatasetType.RANDOM), reversed = new Dataset(50000, DatasetType.REVERSED), ordered = new Dataset(50000, DatasetType.ORDERED);
        datasets.Add(random);
        datasets.Add(reversed);
        datasets.Add(ordered);

        Console.WriteLine("█▀▀ █▀█ █▀▄▀█ █▀█ █▀█ █▀█ █ █▀ █▀█ █▄ █   █▀█ █▀▀   █▀ █▀█ █▀█ ▀█▀ █ █▄ █ █▀▀   █▀█ █   █▀▀ █▀█ █▀█ █ ▀█▀ █ █ █▀▄▀█ █▀");
        Console.WriteLine("█▄▄ █▄█ █ ▀ █ █▀▀ █▀█ █▀▄ █ ▄█ █▄█ █ ▀█   █▄█ █▀    ▄█ █▄█ █▀▄  █  █ █ ▀█ █▄█   █▀█ █▄▄ █▄█ █▄█ █▀▄ █  █  █▀█ █ ▀ █ ▄█");
        Console.WriteLine();
        Console.WriteLine("                        █▀▀ █▀█ █▀█   ▀█▀ █ █▀▄▀█ █▀▀   █▀▀ █▀▀ █▀▀ █ █▀▀ █ █▀▀ █▄ █ █▀▀ █▄█");
        Console.WriteLine("                        █▀  █▄█ █▀▄    █  █ █ ▀ █ ██▄   ██▄ █▀  █▀  █ █▄▄ █ ██▄ █ ▀█ █▄▄  █ ");
        // Reset color

        List<SortingResult> results = new List<SortingResult>();

        foreach (var dataset in datasets)
        {
            Console.WriteLine($"{dataset.Name}");
            Console.WriteLine("----------------------");
            //results.Add(Test.Sort("Merge Sort", dataset.Data, Algorithms.MergeSort, isSmallDataset: dataset.Data.Length < 1000 ? true : false, dataset.Name));
            results.Add(Test.Sort("Quick Sort", dataset.Data, Algorithms.QuickSort, isSmallDataset: dataset.Data.Length < 1000 ? true : false, dataset.Name));
            //results.Add(Test.Sort("Insertion Sort", dataset.Data, Algorithms.InsertionSort, isSmallDataset: dataset.Data.Length < 1000 ? true : false, dataset.Name));
            //results.Add(Test.Sort("Heap Sort", dataset.Data, Algorithms.HeapSort, isSmallDataset: dataset.Data.Length < 1000 ? true : false, dataset.Name));
            //results.Add(Test.Sort("Ins. Sort (P)", dataset.Data, ParallelAlgorithms.InsertionSort, isSmallDataset: dataset.Data.Length < 1000 ? true : false, dataset.Name));
            //results.Add(Test.Sort("Merge. Sort (P)", dataset.Data, ParallelAlgorithms.MergeSort, isSmallDataset: dataset.Data.Length < 1000 ? true : false, dataset.Name));
        }

        Console.WriteLine("              ██████╗ ███████╗███████╗██╗   ██╗██╗     ████████╗");
        Console.WriteLine("              ██╔══██╗██╔════╝██╔════╝██║   ██║██║     ╚══██╔══╝");
        Console.WriteLine("              ██████╔╝█████╗  ███████╗██║   ██║██║        ██║   ");
        Console.WriteLine("              ██╔══██╗██╔══╝  ╚════██║██║   ██║██║        ██║   ");
        Console.WriteLine("              ██║  ██║███████╗███████║╚██████╔╝███████╗   ██║   ");
        Console.WriteLine("              ╚═╝  ╚═╝╚══════╝╚══════╝ ╚═════╝ ╚══════╝   ╚═╝");

        // Display the summary table
        Test.DisplaySummaryTable(results);
    }
}
