using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        // Job Info
        public required string Position { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }

        // Bank Info
        public required string BankAccountNumber { get; set; }
        public required string BankName { get; set; }

        // Mali Info
        public decimal TotalEarnings { get; set; }  
        public decimal TotalDeductions { get; set; }  

        // Other
        public bool IsActive { get; set; }

        //Methods
        public decimal CalculateIncomeTax(decimal taxPercentage)
        { 
            return TotalEarnings * taxPercentage;
        }

        public decimal CalculateInsurance(decimal bimePercentage)
        {
            return Salary * bimePercentage;
        }

        public decimal CalculateNetSalary(decimal taxPercentage, decimal bimePercentage)
        {
            TotalDeductions = CalculateIncomeTax(taxPercentage) + CalculateInsurance(bimePercentage);
            TotalEarnings = TotalEarnings - TotalDeductions;
            return TotalEarnings;
        }


    }
}
