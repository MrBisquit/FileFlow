using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileFlow.Types
{
    public class SubDirectory
    {
        List<SubDirectory> subDirectories { get; set; }
        DirectoryInfo directory { get; set; }
    }
}
