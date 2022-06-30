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
    public class Schedule
    {
        public Guid Id { get; set; } //etapa1
        public string Tutor { get; set; } //etapa1
        public Animal Pet { get; set; } //etapa1
        public Service Service { get; set; } //etapa1
        public List <Employee> Employees { get; set; } //etapa1
        public bool TempSpecialNeeds { get; set; } //etapa1
        public string Notes { get; set; }//etapa1
        public DateTime ScheduleDateTime { get; set; }//etapa1
        public double ValueDiscount { get; set; }//etapa1
        public double ServiceValueExpected { get; set; }//etapa1
        public DateTime ScheduledIn { get; set; }//etapa1
        public StatusScheduling ScheduleStatus { get; set; }//etapa1
        public IncidentLevel IncidentLevel { get; set; }
        public DateTime departureDateTimeExpected { get; set; }
        public DateTime departureDateTimeReal { get; set; }
        public double ValueFine { get; set; }
        public double ServiceValueReal { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        public Schedule(string tutor, ref Animal pet, Service service, List<Employee> employees, bool isSpecial, string notes, DateTime scheduleDateTime, double valueDiscount, double serviceValueExpected)
        {
            Id = Guid.NewGuid();
            Tutor = tutor;
            Pet = pet;
            Service = Service;
            Employees = employees;
            TempSpecialNeeds = isSpecial;
            Notes = notes;
            ScheduleDateTime = scheduleDateTime;
            ValueDiscount = valueDiscount;
            ServiceValueExpected = serviceValueExpected;
            ScheduleStatus = StatusScheduling.PréAgendado;
            ScheduledIn = DateTime.Now;
        }
    }
}
