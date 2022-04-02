using FlightInfoProcessor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FlightInfoProcessor.RuleEngine
{
    public class OnTimeRule : IRules
    {
        public async Task ProcessRules(List<Match> matchingData, FlightInfo flightInfo)
        {
            var stronTimeRegEx = @"^[a-zA-Z0-9]{1}$";
            var onTimeRegEx = new Regex(stronTimeRegEx);
            for (int i = 0; i < matchingData.Count; i++)
            {
                if (i == matchingData.Count - 2 && onTimeRegEx.IsMatch(matchingData[i].Value))
                {
                    flightInfo.Ontime = matchingData[i].Value;
                }
            }   
        }
    }
}
