using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarnaDomain.Entities;

namespace MarnaApplication.Extentions
{
    public static class EmployeeExtentions
    {
        public static void ChangeSalary(this Employee employee, double percentage)
        {
            employee.Salary += (employee.Salary * (decimal)percentage) / 100;
        }
        public static void ChangeEmployeeExperience(this Employee employee, int years)
        {
            employee.Experience += years;
        }
    }
}