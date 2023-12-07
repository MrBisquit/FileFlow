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
        private string? _ConfigLocation = null;
        private CacheConfig? _Config = null;

        public string ConfigLocation { get { return _ConfigLocation == null ? "" : _ConfigLocation; } }
        public CacheConfig? Config { get { return _Config; } }
        public Caching(string ConfigLocation)
        {
            _ConfigLocation = ConfigLocation;

            Initialise();
        }

        private void Initialise()
        {
            if(System.IO.File.Exists(_ConfigLocation))
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
            if (_ConfigLocation == null) return;
            System.IO.File.WriteAllText(_ConfigLocation, JsonSerializer.Serialize(_Config));
        }

        private void LoadConfig()
        {
            if (_ConfigLocation == null) return;
            _Config = JsonSerializer.Deserialize<CacheConfig>(System.IO.File.ReadAllText(_ConfigLocation));
        }
    }
}
