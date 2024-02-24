using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarnaApplication.Dtos.EmployeeDtos;
using MarnaDomain;
using MarnaDomain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        [HttpPut("AddOverTime")]
        public async Task<ActionResult<IEnumerable<OverTime>>> OverTime(OverTimeDto overTime)
        {
            var employee = await _context.Employees.FindAsync(overTime.Id);
            var overtime = new OverTime{
                HoursWorked = overTime.OverTimeHours
            };
            employee.OverTimeRecords.Add(overtime);
            _context.Entry(employee).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(employee.OverTimeRecords);
        }
    }
}