using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FileFlow.Types
{
    public class CacheConfig
    {
        [JsonPropertyName("Files")]
        public List<CacheFile> Files = new List<CacheFile>();
    }
    public class CacheFile
    {
        private string _FileName = "";
        private string _OriginalFileName = "";
        private DateTime _SavedAt = DateTime.MinValue;

        private bool IsReadOnly = false;

        [JsonPropertyName("FileName")]
        public string FileName { get { return _FileName; } set { if (IsReadOnly) { return; } _FileName = value; } }
        [JsonPropertyName("OriginalFileName")]
        public string OriginalFileName { get { return _OriginalFileName; } set { if (IsReadOnly) { return; } _OriginalFileName = value; } }
        [JsonPropertyName("SavedAt")]
        public DateTime SavedAt { get { return _SavedAt; } set { if (IsReadOnly) { return; } _SavedAt = value; } }
    }
}
