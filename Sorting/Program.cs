using Sorting;
using System.Data;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

class Program
{   
    static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.White;

        List<Dataset> datasets = new List<Dataset>();
        List<ExportResult> results = new List<ExportResult>();

        // Samplesize är hur många gånger varje algoritm ska köras.
        int datasetSize = 10000, sampleSize = 20;
        Dataset random = new Dataset(datasetSize, DatasetType.RANDOM), reversed = new Dataset(datasetSize, DatasetType.REVERSED), ordered = new Dataset(datasetSize, DatasetType.ORDERED);
        datasets.Add(random);
        datasets.Add(reversed);
        datasets.Add(ordered);

        Console.WriteLine("█▀▀ █▀█ █▀▄▀█ █▀█ █▀█ █▀█ █ █▀ █▀█ █▄ █   █▀█ █▀▀   █▀ █▀█ █▀█ ▀█▀ █ █▄ █ █▀▀   █▀█ █   █▀▀ █▀█ █▀█ █ ▀█▀ █ █ █▀▄▀█ █▀");
        Console.WriteLine("█▄▄ █▄█ █ ▀ █ █▀▀ █▀█ █▀▄ █ ▄█ █▄█ █ ▀█   █▄█ █▀    ▄█ █▄█ █▀▄  █  █ █ ▀█ █▄█   █▀█ █▄▄ █▄█ █▄█ █▀▄ █  █  █▀█ █ ▀ █ ▄█");
        Console.WriteLine();
        Console.WriteLine("                        █▀▀ █▀█ █▀█   ▀█▀ █ █▀▄▀█ █▀▀   █▀▀ █▀▀ █▀▀ █ █▀▀ █ █▀▀ █▄ █ █▀▀ █▄█");
        Console.WriteLine("                        █▀  █▄█ █▀▄    █  █ █ ▀ █ ██▄   ██▄ █▀  █▀  █ █▄▄ █ ██▄ █ ▀█ █▄▄  █ ");
        // Reset color

        foreach (var dataset in datasets)
        {
            ExportResult data_result = new ExportResult(datasetSize, dataset.Name);

            Console.WriteLine($"{dataset.Name}");
            Console.WriteLine("----------------------");

            Tester("Insertion Sort", data_result, dataset, sampleSize, Algorithms.InsertionSort);
            Tester("Insertion Sort (P)", data_result, dataset, sampleSize, ParallelAlgorithms.InsertionSort);
            Tester("Merge Sort", data_result, dataset, sampleSize, Algorithms.MergeSort);
            Tester("Merge Sort (P)", data_result, dataset, sampleSize, ParallelAlgorithms.MergeSort);
            Tester("Quick Sort", data_result, dataset, sampleSize, Algorithms.QuickSort);
            Tester("Quick Sort (P)", data_result, dataset, sampleSize, ParallelAlgorithms.QuickSort);
            Tester("Heap Sort", data_result, dataset, sampleSize, Algorithms.HeapSort);
            Tester("Heap Sort (P)", data_result, dataset, sampleSize, ParallelAlgorithms.HeapSort);

            results.Add(data_result);
        }

        Console.WriteLine("              ██████╗ ███████╗███████╗██╗   ██╗██╗     ████████╗");
        Console.WriteLine("              ██╔══██╗██╔════╝██╔════╝██║   ██║██║     ╚══██╔══╝");
        Console.WriteLine("              ██████╔╝█████╗  ███████╗██║   ██║██║        ██║   ");
        Console.WriteLine("              ██╔══██╗██╔══╝  ╚════██║██║   ██║██║        ██║   ");
        Console.WriteLine("              ██║  ██║███████╗███████║╚██████╔╝███████╗   ██║   ");
        Console.WriteLine("              ╚═╝  ╚═╝╚══════╝╚══════╝ ╚═════╝ ╚══════╝   ╚═╝");

        // Display the summary table
        Test.DisplaySummaryTable(results);

        string json_raw = JsonConvert.SerializeObject(results, Formatting.Indented);
        using (StreamWriter output = new StreamWriter(Path.Combine(Environment.CurrentDirectory, "output.json")))
        {
            output.WriteLine(json_raw);
        }

    }

    public static void Tester(string name, ExportResult data_result, Dataset dataset, int amount, Action<int[]> action)
    {
        SortingResult result = new SortingResult(name);
        for (int i = 0; i < amount; i++)
        {
            Test.Sort(result, dataset.Data, action, dataset.Name);
        }
        data_result.Results.Add(result);
    }
}
