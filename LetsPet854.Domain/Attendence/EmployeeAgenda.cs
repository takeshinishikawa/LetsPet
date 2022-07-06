using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsPet854.Domain.Attendence
{
    public class EmployeeAgenda
    {
        public string EmployeeName { get; set; }
        public Dictionary<DateOnly, DailyAgenda> Agenda { get; set; }
        public EmployeeAgenda(string employeeName, DateOnly date, TimeOnly startTime, TimeOnly startLunchTime, TimeOnly endLunchTime, TimeOnly endTime)
        {
            EmployeeName = employeeName;
            Agenda = new Dictionary<DateOnly, DailyAgenda>();
            Agenda.Add(date, new DailyAgenda(startTime, startLunchTime, endLunchTime, endTime));
        }
    }
}
