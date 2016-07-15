using AspNetCoreWebApiOverview.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCoreWebApiOverview.Controllers
{
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private MyDbContext dbContext;

        public EmployeesController(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return this.dbContext.Employees.ToList();
        }

        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return this.dbContext.Employees.FirstOrDefault(e => e.Id == id);
        }

        [HttpPost]
        [Produces("application/json", Type = typeof(Employee))]
        public IActionResult Post([FromBody]Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            this.dbContext.Employees.Add(employee);
            this.dbContext.SaveChanges();

            return CreatedAtAction("Get", new { id = employee.Id }, employee);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
