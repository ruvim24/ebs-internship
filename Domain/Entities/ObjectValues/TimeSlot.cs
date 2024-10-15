using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.ObjectValues
{
        public class TimeSlot
        {
            public DateTime StartTime { get; private set; }
            public DateTime EndTime { get; private set; }
            public TimeSpan Duration => EndTime - StartTime;
            public TimeSlot(DateTime startTime, DateTime endTime)
            {
                StartTime = startTime;
                EndTime = endTime;
            }

            public bool IsAvailable(TimeSpan duration)
            {
                return Duration >= duration;
            }
        }
}
