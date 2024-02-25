using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarnaDomain.Entities;
using Microsoft.Identity.Client;

namespace MarnaApplication.Interfaces
{
    public interface IEmployeeService : IDisposable
    {
        public Task<IEnumerable<Employee>> GetAllEmployees();
        public Task<Employee> GetEmployee(Guid Id);
        public Task InsertEmployee(Employee employee);
        public Employee UpdateEmployee(Employee employee);
        public Employee DeleteEmployee(Employee employee);
        public Task DeleteEmployee(Guid Id);
        public Task Save();
    }
}