using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestonHicks.RandomEncounterGenerator.Models
{
    public class EncounterTable
    {
        public string Id { get; set; }
        private List<Encounter> _table;
        //public List<Encounter> Table
        //{
        //    set
        //    {
        //        var FinalList = new List<Encounter>();
        //        FinalList.AddRange(new Encounter[value.Count]);
        //        foreach (var Encounter in value)
        //        {
        //            var SuccessRangeArray = Encounter.SuccessRange.Split(',');
        //            foreach (var number in SuccessRangeArray)
        //            {
        //                int ConvertedIndex = 0;
        //                if (Int32.TryParse(number, out ConvertedIndex))
        //                {
        //                    FinalList[ConvertedIndex - 1] = Encounter;
        //                }
        //                else
        //                {
        //                    throw new Exception("Invalid SuccessRange in table: " + Id);
        //                }

        //            }

        //        }
        //        var a = FinalList.Contains(null);
        //        if (FinalList.Count != value.Count || FinalList.Contains(null))
        //        {
        //            throw new Exception("Success Values are invalid");
        //        }
        //        else
        //        {
        //            _table = FinalList;
        //        }
        //    }
        //    get
        //    {
        //        return _table;
        //    }
        //}
        public List<Encounter> Table
        {
            set
            {
                var FinalList = new List<Encounter>();
                foreach (var Encounter in value)
                {
                    switch (Encounter.SuccessRange.Count)
                    {
                        case 0:
                            throw new Exception("Success Range is null");
                        case 1:
                            FinalList.Add(Encounter);
                            break;
                        case 2:
                            var Range = Math.Abs(Encounter.SuccessRange[0] - Encounter.SuccessRange[1]) + 1;
                            for (int i = 0; i < Range; i++)
                            {
                                FinalList.Add(Encounter);
                            }
                            break;
                        default:
                            throw new Exception("Success Range contains more than 2 numbers: " + Encounter.SuccessRange.ToString());    
                    }
                }
                _table = FinalList;
            }
            get
            {
                return _table;
            }
        }
    }
    public class Encounter
    {
        public List<int> SuccessRange { get; set; }
        public string Description { get; set; }
        public Dictionary<string, string> Link { get; set; }
    }
}
