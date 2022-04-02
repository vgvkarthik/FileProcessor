using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using FlightInfoProcessor.Models;
using FlightInfoProcessor.RuleEngine.Factory;

namespace FlightInfoProcessor.Processor
{
    public class Processor : IProcessor
    {
        private readonly IRulesFactory rulesFactory;
        public Processor(IRulesFactory rulesFactory)
        {
            this.rulesFactory = rulesFactory;
        }
        public async Task<List<FlightInfo>> ProcessFlightInfo()
        {
            var stringBetweenSpace = @"(?<=\s)(.*?)(?=\s)";
            var flightData = new Regex(stringBetweenSpace);
            var fileInfoList = new List<FlightInfo>();
            try
            {
                var lines = File.ReadAllLines(@"<AddPathHere>\flightdata.txt");
                foreach (var line in lines)
                {
                    var matchingData = flightData.Matches(line).Where(x => !string.IsNullOrEmpty(x.Value)).ToList();
                    if (matchingData != null)
                    {
                        var flightInfo = new FlightInfo();
                        flightInfo.Classes = new List<string>();
                        var rules = rulesFactory.CreateRules();
                        var tasks = new List<Task>();
                        foreach (var rule in rules)
                        {
                            tasks.Add(rule.ProcessRules(matchingData, flightInfo));
                        }
                        try
                        {
                            await Task.WhenAll(tasks);
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                       
                        if (tasks.All(t => t.IsCompleted) && tasks.All(t => t.Status == TaskStatus.RanToCompletion))
                        {
                            fileInfoList.Add(flightInfo);
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            
            return fileInfoList;
        }
    }
}
