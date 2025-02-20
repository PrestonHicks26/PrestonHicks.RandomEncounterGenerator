using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestonHicks.RandomEncounterGenerator.Models
{
    public class EnvironmentSpecificEncounter: IEncounter
    {
        public string SuccessValues { get; set; }
        public string Description { get; set; }
        public Dictionary<string, string> Environments { get; set; }
    }
}
