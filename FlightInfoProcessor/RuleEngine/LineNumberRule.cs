using FlightInfoProcessor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FlightInfoProcessor.RuleEngine
{
    public class LineNumberRule : IRules
    {
        public async Task ProcessRules(List<Match> matchingData, FlightInfo flightInfo)
        {
            var strLineNumberRegEx = @"^\d$";
            var LineNumberRegEx = new Regex(strLineNumberRegEx);            
            if (LineNumberRegEx.IsMatch(matchingData[0].Value))
            {
                int.TryParse(matchingData[0].Value, out int linenumber);
                flightInfo.LineNumber = linenumber;
            }
            else
            {
                flightInfo.LineNumber = matchingData[0].Value[0];
            }
        }
    }
}
