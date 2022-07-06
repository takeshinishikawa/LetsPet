using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsPet854.Domain.Attendence
{
    public class DailyAgenda
    {
        public TimeOnly StartTime { get; set; }
        public TimeOnly StartLunchTime { get; set; }
        public TimeOnly EndLunchTime { get; set; }
        public TimeOnly EndTime { get; set; }

        public Dictionary<TimeOnly, char> DAgenda { get; set; }


        public DailyAgenda(TimeOnly startTime, TimeOnly startLunchTime, TimeOnly endLunchTime, TimeOnly endTime)
        {

            StartTime = startTime;
            StartLunchTime = startLunchTime;
            EndLunchTime = endLunchTime;
            EndTime = endTime;
            DAgenda = new Dictionary<TimeOnly, char>();
            InitAgenda();
        }
        /**
         * F - Free
         * L - Lunch
         * S - Scheduled
         */
        public void InitAgenda()
        {
            TimeOnly timeCounter = StartTime;
            while (timeCounter.CompareTo(EndTime) <= 0)
            {
                if (timeCounter < StartLunchTime)
                    DAgenda.Add(timeCounter, 'F');
                else if (timeCounter >= StartLunchTime && timeCounter < EndLunchTime)
                    DAgenda.Add(timeCounter, 'L');
                else if (timeCounter >= EndLunchTime && timeCounter < EndTime)
                    DAgenda.Add(timeCounter, 'F');
                timeCounter = timeCounter.AddMinutes(1);
            }
        }
        public bool SearchDateRange(TimeOnly initial, TimeOnly end)
        {
            return (initial.IsBetween(StartTime, StartLunchTime) && end.IsBetween(StartTime, StartLunchTime) || initial.IsBetween(EndLunchTime, EndTime) && end.IsBetween(EndLunchTime, EndTime));
        }
        public bool SlotFree(TimeOnly initial, TimeOnly end)
        {
            TimeOnly timeCounter = initial;
            while (timeCounter.CompareTo(end) < 0)
            {
                char value;
                if (DAgenda.TryGetValue(timeCounter, out value))
                {
                    if (value != 'F')
                        return false;
                }
                timeCounter = timeCounter.AddMinutes(1);
            }
            return true;
        }
    }
}
