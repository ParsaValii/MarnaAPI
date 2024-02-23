using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarnaDomain;
using MarnaDomain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MarnaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly MarnaDbContext _context;

        public EmployeeController(MarnaDbContext context)
        {
            _context = context;
        }
        [HttpGet("{Id}")]
        public async Task<Employee?> GetEmployeeInfo(Guid Id)
        {
            var Employee = await _context.Employees.FindAsync(Id);
            if (Employee == null)
            {
                return null;
            }
            return Employee;
        }

    }
}