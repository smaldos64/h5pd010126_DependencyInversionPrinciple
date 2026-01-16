using DependencyInversionPrinciple.Enums;
using DependencyInversionPrinciple.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversionPrinciple.Interfaces
{
    public interface IEmployeeSearchable2
    {
        IEnumerable<Employee> GetEmployeesByGenderAndPosition(Gender gender, Position position);
    }
}
