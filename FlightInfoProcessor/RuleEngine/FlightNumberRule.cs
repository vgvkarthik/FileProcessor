using FlightInfoProcessor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FlightInfoProcessor.RuleEngine
{
    public class FlightNumberRule : IRules
    {
        public async Task ProcessRules(List<Match> matchingData, FlightInfo flightInfo)
        {
            var strFlightNumberRegEx = @"[a-zA-Z]{2}\d{4}$";
            var flightNumberRegEx = new Regex(strFlightNumberRegEx);
            var strFlightNumberWithOperatorRegEx = @"^[0-9a-zA-Z:]{6}\d{4}";
            var flightNumberWithOperatorRegEx = new Regex(strFlightNumberWithOperatorRegEx);

            //There is logic here
            if(flightNumberRegEx.IsMatch(matchingData[1].Value))
            {
                flightInfo.Carrier = matchingData[1].Value.Substring(0,2);
                flightInfo.FlightNumber = matchingData[1].Value.Substring(2, 4);
            }
            else if(flightNumberWithOperatorRegEx.IsMatch(matchingData[0].Value))
            {
                flightInfo.OperatingCarrier = matchingData[0].Value.Substring(1, 2);
                flightInfo.Carrier = matchingData[0].Value.Substring(4, 2);
                flightInfo.FlightNumber = matchingData[0].Value.Substring(6, 4);
            }
        }
    }
}
