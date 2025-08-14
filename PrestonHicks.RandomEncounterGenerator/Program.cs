using PrestonHicks.RandomEncounterGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using PrestonHicks.RandomEncounterGenerator;
using System.Runtime.CompilerServices;

// Program startup code

var DataLoader = new DataLoader();
Console.WriteLine("Welcome to the Encounter Generator!");
var Continue = "y";
while (Continue == "y")
{
    var ResponseParameters = "";
    var RollsList = new List<int>();
    var GeneratorList = new List<Generator>();

    Console.WriteLine("Please enter generation parameters in the format \"region,environment,manual roll?,number of encounters\"");
    ResponseParameters = Console.ReadLine();
    if (ResponseParameters == null) continue;

    string[] ResponseParametersArray = ResponseParameters.Split(",");
    var Region = ResponseParametersArray[0];
    var Environment = ResponseParametersArray[1];
    var ManualRoll = bool.Parse(ResponseParametersArray[2]);
    var NumberOfEncounters = int.Parse(ResponseParametersArray[3]);

    if (ManualRoll)
    {

        while (true)
        {
            Console.WriteLine("Please enter numbers rolled in the format \"#,#,#\"");
            var ResponseRolls = Console.ReadLine();
            if (ResponseRolls == null) continue;

            var ResponseRollsArray = ResponseRolls.Split(",");
            if (ResponseRollsArray.Length != NumberOfEncounters) continue;
            foreach (var Roll in ResponseRollsArray)
            {
                RollsList.Add(int.Parse(Roll) - 1);
            }
            break;
        }
        foreach (int Roll in RollsList)
        {
            GeneratorList.Add(new Generator(DataLoader, Region, Environment, Roll));
        }
    }
    else
    {
        for (int i = 0; i < NumberOfEncounters; i++)
        {
            GeneratorList.Add(new Generator(DataLoader, Region, Environment, null));
        }
    }

    var roll = 1;
    foreach (Generator Gen in GeneratorList)
    {
        Console.WriteLine("------------------------------");
        Console.WriteLine($"Results Rolled for Roll {roll}:");
        Console.WriteLine(Gen.ResultsRolled);
        Console.WriteLine($"Encounter Rolled for Roll {roll}:");
        Console.WriteLine(Gen.EncounterRolled);
        roll++;
    }

    while (true)
    {
        Console.WriteLine("Would you like to generate another set of encounters? (y/n)");
        Continue = Console.ReadLine();
        if (Continue != "y" & Continue != "n") continue;
        break;
    }
}






//temp debug
//var DataLoader = new DataLoader();
//for (int i = 0; i < 20; i++)
//{
//    var Generator = new Generator(DataLoader, "The North", "Forest", null);
//}



