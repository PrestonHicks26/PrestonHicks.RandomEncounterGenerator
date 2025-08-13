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
        private int? _initialRoleValue;
        private string? _environment;
        private DataLoader _dataLoader;
        private EncounterTable _regionTable;
        public string ResultsRolled = ""; // list of tables and result from each table
        public string EncounterRolled = ""; // value of 'description' of final table
        public Generator(DataLoader dataLoader, string region, int? roleValue, string? environment)
        {
            _initialRoleValue = roleValue;
            _environment = environment;
            _dataLoader = dataLoader;
            _regionTable = _dataLoader.EncounterTableDictionary[region];
            Console.WriteLine("generator created with parameters: " + region + environment + roleValue);
            if(_initialRoleValue == null)
            {
                var rand = new Random();
                _initialRoleValue = rand.Next(1,_regionTable.Table.Count + 1);
                Console.WriteLine("Random Role: " + _initialRoleValue);
            }
            GenerateEncounter(_initialRoleValue, _regionTable);
        }

        public void GenerateEncounter(int? rollValue, EncounterTable encounterTable)
        {
            // Add table id to ResultsRolled
            // Select encounter from current table given rolled value
            // Add encounter description to ResultsRolled
            // Select link given environment
            // Generate roll given link
            // if link exists, call GenerateEncounter again with value of next table and value of roll
        }
    }
}
