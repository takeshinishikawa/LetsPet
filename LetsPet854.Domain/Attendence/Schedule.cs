using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsPet854.Domain.Common.Enuns;
using LetsPet854.Domain.Pets;
using LetsPet854.Domain.Employees;

namespace LetsPet854.Domain.Attendence
{
    internal class Schedule
    {
        public int id { get; set; }
        public string tempTutor { get; set; }
        public Animal pet { get; set; }
        public Dictionary <Service, List<Employee>> serviceEmployees { get; set; }
        public bool tempSpecialNeeds { get; set; }
        public string notes { get; set; }
        public DateTime scheduleDateTime { get; set; }
        public double serviceValueExpected { get; set; }
        public bool confirmedSchedule { get; set; }
        public double valueDiscount { get; set; }
        public StatusScheduling scheduleStatus { get; set; }
        public string incident { get; set; }
        public IncidentLevel incidentLevel { get; set; }
        public DateTime departureDateTimeExpected { get; set; }
        public DateTime departureDateTimeReal { get; set; }
        public double MyProperty { get; set; }

    }
}
