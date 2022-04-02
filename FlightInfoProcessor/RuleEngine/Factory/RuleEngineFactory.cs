using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightInfoProcessor.RuleEngine.Factory
{
    public interface IRulesFactory
    {
        List<IRules> CreateRules();
    }
    public class RulesFactory : IRulesFactory
    {
        public List<IRules> CreateRules()
        {
            return new List<IRules>() 
            {
                new LineNumberRule(), 
                new FlightNumberRule(), 
                new ClassRule(), 
                new AirportRule(), 
                new TimeRule(), 
                new EquipmentRule(), 
                new OnTimeRule(), 
                new DurationRule() 
            };
        }
    }
}
