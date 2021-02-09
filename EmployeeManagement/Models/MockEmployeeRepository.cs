using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;
        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee() { Id = 1, Name = "Mary", Department = Dept.HR, Email = "mary@pragimtech.com" },
                new Employee() { Id = 2, Name = "John", Department = Dept.IT, Email = "john@pragimtech.com" },
                new Employee() { Id = 3, Name = "Sam", Department = Dept.IT, Email = "sam@pragimtech.com" }
            };
        }

        public Employee GetEmployee(int id)
        {
            return _employeeList.FirstOrDefault(e => e.Id == id); 
        }
        public List<Employee> GetEmployee()
        {
            return _employeeList.ToList();
        }

        public Employee ADD(Employee Employee)
        {
            Employee.Id = _employeeList.Max(e => e.Id) + 1;
            _employeeList.Add(Employee);
            return Employee;
        }
        public Employee Update(Employee Employee)
        {

            Employee employee = _employeeList.FirstOrDefault(e => e.Id == Employee.Id);
            if(employee!=null)
            {
                employee.Name = Employee.Name;
                employee.Email = Employee.Email;
                employee.Department = Employee.Department;
            }
            return employee;
        }
        public Employee Delete(int id)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                _employeeList.Remove(employee);
            }
            return employee;
        }
    }
}
