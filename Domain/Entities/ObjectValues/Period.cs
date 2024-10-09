using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.ObjectValues
{
    public class Period
    {
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }

        public TimeSpan Duration  => EndTime - StartTime;
        public Period(DateTime startTime, DateTime endTime) 
        {
            StartTime = startTime;
            EndTime = endTime;
        }
    }
}
