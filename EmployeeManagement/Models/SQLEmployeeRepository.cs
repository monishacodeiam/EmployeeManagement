using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext context;
        public SQLEmployeeRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Employee ADD(Employee Employee)
        {
            context.Employees.Add(Employee);
            context.SaveChanges();
            return Employee;
        }

        public Employee Delete(int id)
        {
            Employee employee = context.Employees.FirstOrDefault(e => e.Id == id);
            if(employee!=null)
            {
                context.Remove(employee);
                context.SaveChanges();
            }
            return employee;
        }

        public Employee GetEmployee(int id)
        {
            return context.Employees.FirstOrDefault(e => e.Id == id);
        }

        public List<Employee> GetEmployee()
        {
            return context.Employees.ToList();
        }

        public Employee Update(Employee Employee)
        {
            var employee = context.Employees.Attach(Employee);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return Employee;
        }
    }
}
