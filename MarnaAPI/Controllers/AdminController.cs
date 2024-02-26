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
using MarnaApplication.Services;
using MarnaApplication.Interfaces;

namespace MarnaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly MarnaDbContext _context;
        private readonly IEmployeeService _employeeService;

        public AdminController(MarnaDbContext context, IEmployeeService employeeService)
        {
            _context = context;
            _employeeService = employeeService;
        }

        // GET: api/Admin
        [HttpGet("GetAllEmployees")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var employees = await _employeeService.GetAllEmployees();
            return Ok(employees);
        }

        // GET: api/Admin/5
        [HttpGet("GetOneEmployee{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(Guid id)
        {
            var employee = await _employeeService.GetEmployee(id);
            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // PUT: api/Admin/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("UpdateEmployee{id}")]
        public async Task<IActionResult> UpdateEmployee(Guid id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }
            _employeeService.UpdateEmployee(employee);
            await _employeeService.Save();
            return NoContent();
        }

        // POST: api/Admin
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("AddEmployee")]
        public async Task<ActionResult<Employee>> AddEmployee(Employee employee)
        {
            await _employeeService.InsertEmployee(employee);
            await _employeeService.Save();

            return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
        }

        // DELETE: api/Admin/5
        [HttpDelete("DeleteEmployee{id}")]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            await _employeeService.DeleteEmployee(id);
            await _employeeService.Save();

            return NoContent();
        }
        [HttpPost("changeSalary")]
        public async Task<ActionResult<Employee>> ChangeSalary(ChangeSalaryDto changeSalaryDto)
        {
            var employee = await _employeeService.GetEmployee(changeSalaryDto.Id);
            employee.ChangeSalary(changeSalaryDto.percentage);
            _employeeService.UpdateEmployee(employee);
            await _employeeService.Save();
            return Ok(employee);
        }
    }
}
