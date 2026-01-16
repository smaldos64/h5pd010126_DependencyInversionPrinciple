using DependencyInversionPrinciple.Enums;
using DependencyInversionPrinciple.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversionPrinciple.Interfaces
{
    public interface IEmployeeSearchable3<T> where T : class, IPersonData3
    {
        IEnumerable<T> GetDataByGenderAndPosition(Gender gender, Position position);
    }
}
