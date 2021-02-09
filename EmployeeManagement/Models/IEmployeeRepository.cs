using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(int id);
        List<Employee> GetEmployee();
        Employee ADD(Employee Employee);
        Employee Update(Employee Employee);
        Employee Delete(int id);
    }
}
