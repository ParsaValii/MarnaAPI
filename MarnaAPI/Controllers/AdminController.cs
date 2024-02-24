using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarnaDomain;
using MarnaDomain.Entities;
using MarnaApplication.Extentions;
using MarnaApplication.Dtos.AdminDtos;

namespace MarnaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly MarnaDbContext _context;

        public AdminController(MarnaDbContext context)
        {
            _context = context;
        }

        // GET: api/Admin
        [HttpGet("GetAllEmployees")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var employees = await _context.Employees.Include(e => e.OverTimeRecords).ToListAsync();
            return employees;
        }

        // GET: api/Admin/5
        [HttpGet("GetOneEmployee{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(Guid id)
        {
            var employee = await _context.Employees.Include(e => e.OverTimeRecords).FirstOrDefaultAsync(x => x.Id==id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // PUT: api/Admin/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("UpdateEmployee{id}")]
        public async Task<IActionResult> PutEmployee(Guid id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Admin
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("AddEmployee")]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
        }

        // DELETE: api/Admin/5
        [HttpDelete("DeleteEmployee{id}")]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpPost("changeSalary")]
        public async Task<ActionResult<Employee>> ChangeSalary(ChangeSalaryDto changeSalaryDto)
        {
            var employee = await _context.Employees.FindAsync(changeSalaryDto.Id);
            employee.ChangeSalary(changeSalaryDto.percentage);
            _context.Entry(employee).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(employee);
        }
        [HttpPost("changeEmployeeExperience")]
        public async Task<ActionResult<Employee>> ChangeEmployeeExperience(ChangeEmployeeExperienceDto changeEmployeeExperienceDto)
        {
            var employee = await _context.Employees.FindAsync(changeEmployeeExperienceDto.Id);
            employee.ChangeEmployeeExperience(changeEmployeeExperienceDto.years);
            _context.Entry(employee).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(employee);
        }
        [HttpGet("getEmployeeOverTimeRecords")]
        public async Task<ActionResult<IEnumerable<OverTime>>> GetEmployeeOverTimeRecords(Guid id)
        {
            var employee = await _context.Employees.FindAsync(id);
            return Ok(employee.OverTimeRecords);
        }
        private bool EmployeeExists(Guid id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
