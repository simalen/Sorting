using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{

    public class ExportResult
    {   
        public int Datasize { get; }
        public string Name { get; }

        public List<SortingResult> Results;

        public ExportResult(int size, string name)
        {
            Results = new List<SortingResult>();
            Datasize = size;
            Name = name;
        }
    }
}
