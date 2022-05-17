using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zoobook.Api.Models;
using Zoobook.Core.Models;
using Zoobook.Data.Repository;

namespace Zoobook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: api/<EmployeesController>
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return _employeeService.All();
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return _employeeService.Find(id);
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public void Post([FromBody] EmployeeDto employee)
        {
            Employee employeeToCreate = new Employee
            {
                FirstName = employee.FirstName,
                MiddleName = employee.MiddleName,
                LastName = employee.LastName
            };

            _employeeService.Add(employeeToCreate);
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] EmployeeDto value)
        {
            Employee current = _employeeService.Find(id);

            if (current != null)
            {
                current.FirstName = string.IsNullOrEmpty(value.FirstName) ? current.FirstName : value.FirstName;
                current.MiddleName = string.IsNullOrEmpty(value.MiddleName) ? current.MiddleName : value.MiddleName;
                current.LastName = string.IsNullOrEmpty(value.LastName) ? current.LastName : value.LastName;

                _employeeService.Update(current);
            }
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Employee current = _employeeService.Find(id);

            if (current != null)
            {
                _employeeService.Delete(id);
            }
        }
    }
}
