using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class SortingResult
    {
        public string AlgorithmName;
        public string DatasetName;
        public double elapsedMilliseconds;

        public SortingResult(string datasetName, string algorithmName, double elapsedMilliseconds)
        {
            DatasetName = datasetName;
            AlgorithmName = algorithmName;
            this.elapsedMilliseconds = elapsedMilliseconds;
        }
    }
}
