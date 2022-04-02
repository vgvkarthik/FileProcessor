using FlightInfoProcessor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FlightInfoProcessor.RuleEngine
{
    public class EquipmentRule : IRules
    {
        public async Task ProcessRules(List<Match> matchingData, FlightInfo flightInfo)
        {
            var strEquipRegEx = @"^[E0.]";
            var equipRegEx = new Regex(strEquipRegEx);
            for (int i = 0; i < matchingData.Count; i++)
            {
                if (equipRegEx.IsMatch(matchingData[i].Value))
                {
                    flightInfo.Equipment = matchingData[i].Value.Replace("E0.","");
                }
            } 
        }
    }
}
