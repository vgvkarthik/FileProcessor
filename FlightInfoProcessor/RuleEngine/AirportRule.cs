using FlightInfoProcessor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FlightInfoProcessor.RuleEngine
{
    public class AirportRule : IRules
    {
        public async Task ProcessRules(List<Match> matchingData, FlightInfo flightInfo)
        {
            var strAirportRegEx = @"[A-Z]+$";
            var airportRegEx = new Regex(strAirportRegEx);
            for (int i = 0; i < matchingData.Count; i++)
            {
                if (airportRegEx.IsMatch(matchingData[i].Value.Replace("/", "")))
                {
                    if (string.IsNullOrEmpty(flightInfo.DepartureAirport))
                    {
                        flightInfo.DepartureAirport = matchingData[i].Value.Replace("/", "");
                    }
                    else
                    {
                        flightInfo.ArrivalAirport = matchingData[i].Value.Replace("/", "");
                    }
                }
            }            
        }
    }
}
