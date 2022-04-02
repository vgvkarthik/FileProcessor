using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightInfoProcessor.Models;

namespace FlightInfoProcessor.Processor
{
    public interface IProcessor
    {
       public Task<List<FlightInfo>> ProcessFlightInfo();
    }
}
