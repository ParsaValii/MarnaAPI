using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarnaApplication.Dtos.AdminDtos
{
    public class PutSetTotalDeductionsDto
    {
        public decimal TaxPercentage { get; set; }
        public decimal BimePercentage { get; set; }
    }
}