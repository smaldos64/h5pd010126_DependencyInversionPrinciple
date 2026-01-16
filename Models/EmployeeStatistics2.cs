using DependencyInversionPrinciple.Enums;
using DependencyInversionPrinciple.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversionPrinciple.Models
{
    public class EmployeeStatistics2
    {
        private readonly IEmployeeSearchable2 _emp;

        public EmployeeStatistics2(IEmployeeSearchable2 emp)
        {
            _emp = emp;
        }

        public int CountFemaleManagers() =>
        _emp.GetEmployeesByGenderAndPosition(Gender.Female, Position.Manager).Count();
    }
}
