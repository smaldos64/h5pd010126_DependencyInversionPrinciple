using DependencyInversionPrinciple.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversionPrinciple.Models
{
    public class EmployeeStatistics1
    {
        private readonly EmployeeManager1 _empManager;

        public EmployeeStatistics1(EmployeeManager1 empManager)
        {
            _empManager = empManager;
        }

        public int CountFemaleManagers()
        {
            return (_empManager.Employees.Count(emp => emp.Gender == Gender.Female && emp.Position == Position.Manager)); 
        }
    }
}
