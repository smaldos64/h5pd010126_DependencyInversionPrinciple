using DependencyInversionPrinciple.Enums;
using DependencyInversionPrinciple.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversionPrinciple.Models
{
    public class EmployeeManager2 : IEmployeeSearchable2
    {
        private readonly List<Employee2> _employees;

        public EmployeeManager2()
        {
            _employees = new List<Employee2>();
        }

        public void AddEmployee(Employee2 employee)
        {
            _employees.Add(employee);
        }

        public IEnumerable<Employee2> GetEmployeesByGenderAndPosition(Gender gender, Position position)
            => _employees.Where(emp => emp.Gender == gender && emp.Position == position);
    }
}
