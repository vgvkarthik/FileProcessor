using FlightInfoProcessor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FlightInfoProcessor.RuleEngine
{
    public class TimeRule : IRules
    {
        public async Task ProcessRules(List<Match> matchingData, FlightInfo flightInfo)
        {
            var strTimeRegEx = @"^\d{4}$";
            var timeRegEx = new Regex(strTimeRegEx);
            for (int i = 0; i < matchingData.Count; i++)
            {
                if (timeRegEx.IsMatch(matchingData[i].Value))
                {
                    if (string.IsNullOrEmpty(flightInfo.DepartureTime))
                    {
                        flightInfo.DepartureTime = matchingData[i].Value;
                    }
                    else
                    {
                        flightInfo.ArrivalTime = matchingData[i].Value;
                    }
                }
            }
        }
    }
}
