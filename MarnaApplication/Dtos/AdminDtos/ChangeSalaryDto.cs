using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarnaApplication.Dtos.AdminDtos
{
    public class ChangeSalaryDto
    {
        public Guid Id { get; set; }
        public decimal percentage { get; set; }
    }
}