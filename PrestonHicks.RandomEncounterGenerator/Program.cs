using PrestonHicks.RandomEncounterGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using PrestonHicks.RandomEncounterGenerator;

// Program startup code

var DataLoader = new DataLoader();
// UI while loop
// get generator parameters from user and DataLoader
// create new generator
// display generated results to user
// ask if user would like to generate another set of encounters
Console.WriteLine("Welcome to the Encounter Generator!");
var Continue = "y";
while (Continue == "y")
{
    var ResponseParameters = "";
    List<int> RollsList = new List<int>();
    Console.WriteLine("Please enter generation parameters in the format \"region,environment,manual role?,number of encounters\"");
    ResponseParameters = Console.ReadLine();
    if (ResponseParameters == null) continue;
    string[] ResponseParametersArray = ResponseParameters.Split(",");
    var Region = ResponseParametersArray[0];
    var Environment = ResponseParametersArray[1];
    var ManualRole = bool.Parse(ResponseParametersArray[2]);
    var NumberOfEncounters = int.Parse(ResponseParametersArray[3]);
    if (ManualRole)
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
                RollsList.Add(int.Parse(Roll));
            }
            break;
        }
        foreach (int Roll in RollsList)
        {
            var Generator = new Generator(DataLoader, Region, Roll, Environment);
        }
    }
    else
    {
        for(int i = 0; i < NumberOfEncounters; i++)
        {
            var Generator = new Generator(DataLoader, Region, null, Environment);
        }
    }
    
    Console.WriteLine("Would you like to generate another set of encounters? (y/n)");
    Continue = Console.ReadLine();
}





// temp debug
//var DataLoader = new DataLoader();
//for (int i = 0; i < 20; i++)
//{
//    var Generator = new Generator(DataLoader, "The North", null, null);
//}



