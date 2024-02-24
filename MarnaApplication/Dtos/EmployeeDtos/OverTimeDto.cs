using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarnaApplication.Dtos.EmployeeDtos
{
    public class OverTimeDto
    {
        public Guid Id { get; set; }
        public decimal OverTimeHours { get; set; }
    }
}