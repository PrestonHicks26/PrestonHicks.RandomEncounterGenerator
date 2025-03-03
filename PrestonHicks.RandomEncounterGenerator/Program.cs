using PrestonHicks.RandomEncounterGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using PrestonHicks.RandomEncounterGenerator;


var Loader = new DataLoader();
//string[] files = Directory.GetFiles(@"../../../Data", "*", SearchOption.AllDirectories);
//var LoadedTable = new EncounterTable();
//using (StreamReader r = new StreamReader(files[2]))
//{
//    string json = r.ReadToEnd();
//    LoadedTable = JsonConvert.DeserializeObject<EncounterTable>(json);
//}
//var value = LoadedTable.Table[0].Link.GetType().Name;
//var value2 = LoadedTable.Table[1].Link.GetType().Name;
//var value3 = LoadedTable.Table[1].Link.GetType().GetFields();
//var forest = LoadedTable.Table[1].Link.GetValue("forest");
//Console.WriteLine(LoadedTable);
//var encounters = new List<IEncounter>();
//encounters.Add(new Encounter());
//encounters.Add(new EnvironmentSpecificEncounter());
//var table = new EncounterTable("id", encounters);
//var en = (EnvironmentSpecificEncounter)table.Table[1];
//en.Environments = new Dictionary<string, string>();
Console.ReadLine();
