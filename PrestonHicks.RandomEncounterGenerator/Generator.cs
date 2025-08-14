using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrestonHicks.RandomEncounterGenerator.Models;

namespace PrestonHicks.RandomEncounterGenerator
{
    public class Generator
    {
        private int _initialRollValue;
        private string _environment;
        private DataLoader _dataLoader;
        private EncounterTable _regionTable;
        private Random _rand = new Random();

        private string _resultsRolled = "";
        /// <summary>
        /// List of tables and results from each table
        /// </summary>
        public string ResultsRolled
        {
            get { return _resultsRolled; }
        }

        private string _encounterRolled = "";
        /// <summary>
        /// Description value of encounter of final table
        /// </summary>
        public string EncounterRolled
        {
            get { return _encounterRolled; } 
        }

        public Generator(DataLoader dataLoader, string region, string environment, int? regionRollValue)
        {
            _initialRollValue = regionRollValue ?? -1;
            _environment = environment;
            _dataLoader = dataLoader;
            _regionTable = _dataLoader.EncounterTableDictionary[region];
            Console.WriteLine("generator created with parameters: " + region + environment + regionRollValue);
            if(_initialRollValue == -1)
            {
                _initialRollValue = _rand.Next(_regionTable.Table.Count);
                Console.WriteLine("Random Roll: " + _initialRollValue);
            }
            GenerateEncounter(_initialRollValue, _regionTable);
        }

        public void GenerateEncounter(int rollValue, EncounterTable encounterTable)
        {
            var RolledEncounter = encounterTable.Table[rollValue];
            if(RolledEncounter.Link != null)
            {
                string? value = null;
                var Link = RolledEncounter.Link.TryGetValue("Default", out value) ? value : RolledEncounter.Link[_environment];
                var LinkedTable = _dataLoader.EncounterTableDictionary[Link];
                _resultsRolled += $"Rolled a {rollValue + 1}, resulting in a {RolledEncounter.Description} Encounter, linking to {Link} table.\n";
                var LinkedTableRoll = _rand.Next(LinkedTable.Table.Count);
                GenerateEncounter(LinkedTableRoll, LinkedTable);
            }
            else
            {
                _encounterRolled = $"Rolled a {rollValue + 1}, resulting in:\n****{RolledEncounter.Description}****\n";
            }
        }
    }
}
