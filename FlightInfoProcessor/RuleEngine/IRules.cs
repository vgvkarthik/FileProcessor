using FlightInfoProcessor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FlightInfoProcessor.RuleEngine
{
    public interface IRules
    {
        Task ProcessRules(List<Match> matchingData, FlightInfo flightInfo);
    }

}
