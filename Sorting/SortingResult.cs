using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class SortingResult
    {
        public string AlgorithmName { get; }

        public List<double> ElapsedMilliSeconds;

        public SortingResult(string AlgorithmName)
        {
            this.AlgorithmName = AlgorithmName;
            ElapsedMilliSeconds = new List<double>();
        }
    }
}
