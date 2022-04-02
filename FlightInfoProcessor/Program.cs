using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using FlightInfoProcessor.Processor;
using FlightInfoProcessor.RuleEngine.Factory;

IRulesFactory ruleFactory = new RulesFactory();
var processor = new Processor(ruleFactory);
var flightInforTask = processor.ProcessFlightInfo();

if (flightInforTask.IsCompleted && flightInforTask.Status == TaskStatus.RanToCompletion)
{
    using (FileStream fs = File.Create(@"<AddPathHere>\Response.txt"))
    {
        StringBuilder sb = new StringBuilder();
        foreach (var flight in flightInforTask.Result)
        {
            var classes = flight.Classes.Aggregate((a, b) => a + "," + b);
            sb.AppendLine("LineNumber:" + flight.LineNumber);
            sb.AppendLine("FlightNumber:" + flight.FlightNumber);
            sb.AppendLine("Classes :" + classes);
            sb.AppendLine("DepartureAirport:" + flight.DepartureAirport);
            sb.AppendLine("ArrivalAirport:" + flight.ArrivalAirport);
            sb.AppendLine("DepartureTime:" + flight.DepartureTime);
            sb.AppendLine("ArrivalTime:" + flight.ArrivalTime);
            sb.AppendLine("ArrivalTimeShift:" + flight.ArrivalTimeShift);
            sb.AppendLine("Equipment:" + flight.Equipment);
            sb.AppendLine("Ontime:" + flight.Ontime);
            sb.AppendLine("Duration:" + flight.Duration);
        }
        byte[] info = new UTF8Encoding(true).GetBytes(sb.ToString());
        fs.Write(info, 0, sb.Length);
    }
}