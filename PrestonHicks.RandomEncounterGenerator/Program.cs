using PrestonHicks.RandomEncounterGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using PrestonHicks.RandomEncounterGenerator.Models;

var LoadedTable = new EncounterTable();
var a = Environment.ProcessPath;
using (StreamReader r = new StreamReader(@"../../../Data/SampleRegion_TheNorth.json"))
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
