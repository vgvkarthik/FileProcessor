using FlightInfoProcessor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FlightInfoProcessor.RuleEngine
{
    public class ClassRule : IRules
    {
        public async Task ProcessRules(List<Match> matchingData, FlightInfo flightInfo)
        {
            var strClassRegEx = @"[a-zA-Z]{1}\d{1}$";
            var classRegEx = new Regex(strClassRegEx);
            for (int i = 0; i < matchingData.Count; i++)
            {
                if (classRegEx.IsMatch(matchingData[i].Value))
                {
                    flightInfo.Classes.Add(matchingData[i].Value[0].ToString());
                }
            }           
        }
    }
}
