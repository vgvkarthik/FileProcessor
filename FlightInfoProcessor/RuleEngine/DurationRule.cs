using FlightInfoProcessor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FlightInfoProcessor.RuleEngine
{
    public class DurationRule : IRules
    {
        public async Task ProcessRules(List<Match> matchingData, FlightInfo flightInfo)
        {
            var strDurRegEx = @"^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$";
            var durRegEx = new Regex(strDurRegEx);
            for (int i = 0; i < matchingData.Count; i++)
            {
                if (durRegEx.IsMatch(matchingData[i].Value))
                {
                    flightInfo.Duration = matchingData[i].Value;
                }
            }            
        }
    }
}
