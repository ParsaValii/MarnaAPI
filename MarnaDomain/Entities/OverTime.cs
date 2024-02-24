using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarnaDomain.Entities
{
    public class OverTime
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public decimal HoursWorked { get; set; }
    }
}