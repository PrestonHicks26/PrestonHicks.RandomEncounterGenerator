using PrestonHicks.RandomEncounterGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;

namespace PrestonHicks.RandomEncounterGenerator
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            var LoadedTable = new EncounterTable();
            using (StreamReader r = new StreamReader("SampleRegion_TheNorth.json"))
            {
                string json = r.ReadToEnd();
                LoadedTable = JsonConvert.DeserializeObject<EncounterTable>(json);
            }
            Console.WriteLine(LoadedTable);
            var encounters = new List<IEncounter>();
            encounters.Add(new Encounter());
            encounters.Add(new EnvironmentSpecificEncounter());
            var table = new EncounterTable("id", encounters);
            var en = (EnvironmentSpecificEncounter)table.Table[1];
            en.Environments = new Dictionary<string, string>();
            Console.ReadLine();
        }
    }
}
