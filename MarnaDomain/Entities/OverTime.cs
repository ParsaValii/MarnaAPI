using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MarnaDomain.Entities
{
    public class OverTime
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public decimal HoursWorked { get; set; }
        [JsonIgnore]
        public Employee Employee { get; set; }
        public OverTime()
        {
            Date = DateTime.Now;
        }
    }
}