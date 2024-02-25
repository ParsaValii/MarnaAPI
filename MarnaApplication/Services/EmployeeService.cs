using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarnaApplication.Interfaces;
using MarnaDomain;
using MarnaDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MarnaApplication.Services
{
    public class EmployeeService : IEmployeeService
    {
        public readonly MarnaDbContext _context;
        public EmployeeService(MarnaDbContext marnaDbContext)
        {
            _context = marnaDbContext;
        }

        public Employee DeleteEmployee(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Deleted;
            return employee;
        }

        public async Task DeleteEmployee(Guid Id)
        {
            var employee = await GetEmployee(Id);
            DeleteEmployee(employee);
        }

        public async void Dispose()
        {
            await _context.DisposeAsync();
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            var employees = await _context.Employees.Include(x => x.OverTimeRecords).ToListAsync();
            return employees;
        }

        public async Task<Employee> GetEmployee(Guid Id)
        {
            var employee = await _context.Employees.Include(x => x.OverTimeRecords).FirstOrDefaultAsync(x => x.Id == Id);
            if (employee == null)
            {
                return null;
            }
            return employee;
        }

        public async Task InsertEmployee(Employee employee)
        {
            await _context.AddAsync(employee);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public Employee UpdateEmployee(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
            return employee;
        }
    }
}