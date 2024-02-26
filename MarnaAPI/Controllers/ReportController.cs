using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarnaApplication.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MarnaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        public readonly IEmployeeService _employeeService;
        public ReportController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet("GetEmployeeCount")]
        public async Task<ActionResult<int>> GetEmployeeCount()
        {
            int employeesCount = 0;
            var employees = await _employeeService.GetAllEmployees();
            foreach (var item in employees)
            {
                employeesCount += 1;
            }
            return Ok(employeesCount);
        }
    }
}