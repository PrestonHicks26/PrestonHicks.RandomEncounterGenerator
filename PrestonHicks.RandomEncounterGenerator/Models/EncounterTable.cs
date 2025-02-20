using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestonHicks.RandomEncounterGenerator.Models
{
    public class EncounterTable
    {
        private string _Id;
        private List<IEncounter> _Encounters;
        public string Id {
            get { return _Id; }
        }
        public List<IEncounter> Table {
            get { return this._Encounters; }
        }

        public EncounterTable(string id, List<IEncounter> encounters) { 
            _Id = id;
            foreach (IEncounter encounter in encounters)
            {
                encounter.SuccessValues = "";
            }


            _Encounters = encounters;

        }
        public EncounterTable() { }
    }
}
