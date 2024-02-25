using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MarnaDomain.Entities
{
    public class Employee
    {
        // Employee Info
        public Guid Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public required string NationalId { get; set; }
        public required string Email { get; set; }
        public required string Address { get; set; }
        public required string BankAcountNumber { get; set; }
        public DateTime EmploymentStartDate { get; set; }
        public decimal Salary { get; set; }
        public double Experience =>
            (DateTime.Now - EmploymentStartDate).TotalDays / 365;
        public IList<OverTime> OverTimeRecords { get; set; }
        public Employee()
        {
            EmploymentStartDate = DateTime.Now;
            OverTimeRecords = new List<OverTime>();
        }
    }
}
