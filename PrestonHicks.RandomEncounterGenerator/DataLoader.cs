using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PrestonHicks.RandomEncounterGenerator.Models;

namespace PrestonHicks.RandomEncounterGenerator
{
    public class DataLoader
    {
        private Dictionary<string, EncounterTable> _encounterTableDictionary;
        public Dictionary<string, EncounterTable> EncounterTableDictionary
        {
            get { return _encounterTableDictionary; }
        }

        private GeneratorSettings _generatorSettings;
        public GeneratorSettings GeneratorSettings
        {
            get { return _generatorSettings; }
        }
        public DataLoader()
        {
            // Dictionary of tables
            _encounterTableDictionary = new Dictionary<string, EncounterTable>();
            string[] DataFiles = Directory.GetFiles(@"../../../Data/Tables", "*", SearchOption.AllDirectories);
            foreach (string File in DataFiles)
            {
                var LoadedTable = new EncounterTable();
                using (StreamReader r = new StreamReader(@File))
                {
                    string json = r.ReadToEnd();
                    LoadedTable = JsonConvert.DeserializeObject<EncounterTable>(json);
                    _encounterTableDictionary.Add(LoadedTable.Id, LoadedTable);
                }
            }

            // Generator settings
            using (StreamReader r = new StreamReader(@"../../../Data/Settings/SampleGeneratorSettings.json"))
            {
                string json = r.ReadToEnd();
                _generatorSettings = JsonConvert.DeserializeObject<GeneratorSettings>(json);
            }
        }

    }
}
