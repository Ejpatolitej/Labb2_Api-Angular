using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Labb2_Api_Angular.Models;
using System.ComponentModel.DataAnnotations;

namespace Labb2_Api_Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmployeesController(AppDbContext context)
        {
            _context = context;
        }

        // GET
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        // GET BY ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // UPDATE
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id, [FromBody] Employee employee)
        {
            var empToUpdate = await _context.Employees.FirstOrDefaultAsync(x => x.EmployeeId == id);
            if (empToUpdate != null)
            {
                empToUpdate.EmpFirstName = employee.EmpFirstName;
                empToUpdate.EmpLastName = employee.EmpLastName;
                empToUpdate.EmpEmail = employee.EmpEmail;
                empToUpdate.EmpPhone = employee.EmpPhone;
                empToUpdate.EmpGender = employee.EmpGender;
                empToUpdate.DepartmentID = employee.DepartmentID;
                empToUpdate.Salary = employee.Salary;

                await _context.SaveChangesAsync();
                return Ok(employee);
            }
            return NotFound("Employee was not found");
        }

        // POST
        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmployee(Employee employee)
        {
            employee.EmployeeId = Guid.NewGuid();
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = employee.EmployeeId }, employee);
        }

        // DELETE
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
