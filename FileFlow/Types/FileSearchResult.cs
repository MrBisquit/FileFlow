using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static FileFlow.Types.Exceptions;

namespace FileFlow.Types
{
    public class FileSearchResult
    {
        public List<FileInfo> Files { get; set; }
        public void ToResult()
        {
            throw NotImplementedException();
        }
    }
}
