using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarnaDomain.Entities
{
    public class OverTime
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public decimal HoursWorked { get; set; }
    }
}