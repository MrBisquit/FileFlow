using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileFlow.Types
{
    internal class DirectoryStructure
    {
        List<SubDirectory> subdirectories { get; set; }
        DirectoryInfo directory { get; set; }
    }
}
