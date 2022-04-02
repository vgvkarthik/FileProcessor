using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightInfoProcessor.Models
{
    public class FlightInfo
    {
        public int LineNumber { get; set; }
        public string Carrier { get; set; }
        public string OperatingCarrier { get; set; }
        public string FlightNumber { get; set; }
        public List<string> Classes { get; set; }
        public string DepartureAirport { get; set; }
        public string ArrivalAirport { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }
        public string ArrivalTimeShift { get; set; }
        public string Equipment { get; set; }
        public string Ontime { get; set; }
        public string Duration { get; set; }
    }
}
