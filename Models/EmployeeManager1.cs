using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversionPrinciple.Models
{
    public class EmployeeManager1
    {
        private readonly List<Employee1> _employees;

        public EmployeeManager1()
        {
            _employees = new List<Employee1>();
        }

        public void AddEmployee(Employee1 employee)
        {
            _employees.Add(employee);
        }

        public List<Employee1> Employees => _employees;
    }
}
