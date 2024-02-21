using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarnaApplication.Dtos.SalaryDtos
{
    public class MonthlySalaryRequestDto
    {
        public decimal BaseSalary { get; set; }
        public decimal Bonuses { get; set; }
        public int OvertimeHours { get; set; }
    }
}