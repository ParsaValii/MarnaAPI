using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarnaApplication.Dtos.AdminDtos;
using MarnaApplication.Dtos.SalaryDtos;
using MarnaDomain;
using MarnaDomain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarnaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalaryController : ControllerBase
    {
        private const decimal OvertimeRate = 1.5m;
        private readonly MarnaDbContext _context;

        public SalaryController(MarnaDbContext context)
        {
            _context = context;
        }

        // محاسبه حقوق و دستمزد بر اساس اطلاعات ماهانه
        [HttpPost("calculate")]
        public ActionResult<decimal> CalculateSalary([FromBody] MonthlySalaryRequestDto request)
        {
            // انجام محاسبات بر اساس اطلاعات درخواستی
            decimal totalSalary = CalculateTotalSalary(request.BaseSalary, request.Bonuses, request.OvertimeHours);

            return Ok(totalSalary);
        }
        // افزایش دستمزد بر اساس سابقه کار
        [HttpPut("increase")]
        public async Task<ActionResult<decimal>> IncreaseSalary(Guid employeeId)
        {
            // دریافت اطلاعات کارمند بر اساس شناسه
            Employee employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == employeeId);

            // افزایش دستمزد بر اساس سابقه کار
            decimal increasedSalary = IncreaseSalaryBasedOnExperience(employee.Salary, employee.Experience);
            employee.Salary = employee.Salary + increasedSalary;
            _context.Entry(employee).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(increasedSalary);
        }

        // GET: api/Admin/5
        [HttpPut("Deductions")]
        public async Task<ActionResult> SetTotalDeductions(Guid id, [FromBody] PutSetTotalDeductionsDto TotalDeductionsDto)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }
            employee.CalculateNetSalary(TotalDeductionsDto.TaxPercentage, TotalDeductionsDto.BimePercentage);
            _context.Entry(employee).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok();
        }
        // متدهای کمکی برای محاسبات
        private decimal CalculateTotalSalary(decimal baseSalary, decimal bonuses, int overtimeHours)
        {
            // انجام محاسبات و افزودن مزایا و اضافه کاری
            // مثال ساده: حقوق اساسی + مزایا + (ساعت اضافه کاری * نرخ اضافه کاری)
            return baseSalary + bonuses + (overtimeHours * OvertimeRate);
        }

        private decimal IncreaseSalaryBasedOnExperience(decimal baseSalary, int experience)
        {
            // افزایش دستمزد بر اساس سابقه کار
            // مثال ساده: برای هر سال سابقه 5% افزایش
            decimal increasePercentage = 0.05m;
            return baseSalary * (1 + (experience * increasePercentage));
        }
    }
}