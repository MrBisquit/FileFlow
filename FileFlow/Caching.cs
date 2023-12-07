using FileFlow.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FileFlow
{
    public class Caching
    {
        private string? _CacheLocation = null;
        private CacheConfig? _Config = null;

        /// <summary>
        /// The directory which the config file should be in.
        /// </summary>
        public string CacheLocation { get { return _CacheLocation == null ? "" : _CacheLocation; } }
        public CacheConfig? Config { get { return _Config; } }
        public Caching(string CacheLocation)
        {
            if(!System.IO.Directory.Exists(CacheLocation))
            {
                throw new Exception("Invalid CacheLocation field");
            }
            _CacheLocation = CacheLocation;

            Initialise();
        }

        private void Initialise()
        {
            if(System.IO.File.Exists(Path.Combine(_CacheLocation, ".config")))
            {
                LoadConfig();
            } else
            {
                _Config = new CacheConfig();
                SaveConfig();
            }
        }

        private void SaveConfig()
        {
            if (_CacheLocation == null) return;

            if(System.IO.Directory.Exists(_CacheLocation))
            {
                System.IO.Directory.CreateDirectory(_CacheLocation);
            }

            System.IO.File.WriteAllText(_CacheLocation, JsonSerializer.Serialize(_CacheLocation + "\\.config"));
        }

        private void LoadConfig()
        {
            if (_CacheLocation == null) return;
            _Config = JsonSerializer.Deserialize<CacheConfig>(System.IO.File.ReadAllText(_CacheLocation + "\\.config"));
        }

        public void AddFile(FileInfo file)
        {
            if(_Config == null)
            {
                throw new Exception("Config not initialised");
            }

            CacheFile f = new CacheFile();
            f.FileName = Guid.NewGuid().ToString();
            f.OriginalFileName = file.FullName;
            f.SavedAt = DateTime.Now;

            _Config.Files.Add(f);

            if(!System.IO.Directory.Exists(Path.Combine(CacheLocation, "Files"))) { System.IO.Directory.CreateDirectory(Path.Combine(CacheLocation, "Files")); }
            System.IO.File.Copy(file.FullName, Path.Combine(Path.Combine(CacheLocation, "Files"), f.FileName));

            SaveConfig();
        }
    }
}