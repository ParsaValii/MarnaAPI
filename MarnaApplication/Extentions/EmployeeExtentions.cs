using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarnaDomain.Entities;

namespace MarnaApplication.Extentions
{
    public static class EmployeeExtentions
    {
        public static void ChangeSalary(this Employee employee, decimal percentage)
        {
            employee.Salary += (employee.Salary * (decimal)percentage) / 100;
        }
    }
}