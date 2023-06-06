using CrudWebAbi.Database;
using CrudWebAbi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudWebAbi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeDbContext EmployeeDbContext;
        public EmployeeController(EmployeeDbContext employeeDbContext)
        {
            this.EmployeeDbContext = employeeDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployee() 
        {
            var Employees = await EmployeeDbContext.Employees.ToListAsync();
            return Ok(Employees);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] Employee model)
        {
            model.Id = new Guid();

            await EmployeeDbContext.Employees.AddAsync(model);
            await EmployeeDbContext.SaveChangesAsync();
            return Ok(model);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id , [FromBody] Employee model)
        {
             var employee = await EmployeeDbContext.Employees.FirstOrDefaultAsync(a => a.Id == id);
            if (employee != null) 
            {
                employee.Name = model.Name;
                employee.MobileNo = model.MobileNo;
                employee.EmailId = model.EmailId;
                await EmployeeDbContext.SaveChangesAsync();

                return Ok(employee);
            }

            else
            {
                return NotFound("Employee not found");
            }
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
        {
            var employee = await EmployeeDbContext.Employees.FirstOrDefaultAsync(a => a.Id == id);
            if (employee != null)
            {
                EmployeeDbContext.Employees.Remove(employee);
                await EmployeeDbContext.SaveChangesAsync();

                return Ok(employee);
            }

            else
            {
                return NotFound("Employee not found");
            }
        }



    }
}
