using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoobook.Core.Models;
using Zoobook.Data.Models;

namespace Zoobook.Data.Repository
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ZoobookContext _zoobookContext;

        public EmployeeService(ZoobookContext zoobookContext)
        {
             _zoobookContext = zoobookContext;
        }

        public void Add(Employee employee)
        {
            _zoobookContext.Employees.Add(employee);
            _zoobookContext.SaveChanges();
        }

        public IEnumerable<Employee> All()
        {
            return _zoobookContext.Employees.ToList();
        }

        public void Delete(int id)
        {
            var entity = _zoobookContext.Employees.Find(id);

            _zoobookContext.Employees.Remove(entity);
            _zoobookContext.SaveChanges();
        }

        public Employee Find(int id)
        {
            return _zoobookContext.Employees.Find(id);
        }

        public void Update(Employee updatedEntity)
        {
            _zoobookContext.Employees.Update(updatedEntity);
            _zoobookContext.SaveChanges();
        }
    }
}
