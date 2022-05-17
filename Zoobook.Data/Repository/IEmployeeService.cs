using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoobook.Core.Models;

namespace Zoobook.Data.Repository
{
    public interface IEmployeeService
    {
        void Add(Employee employee);
        IEnumerable<Employee> All();
        void Delete(int id);
        Employee Find(int id);
        void Update(Employee updatedEntity);
        
    }
}
