using DependencyInversionPrinciple.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversionPrinciple.Interfaces
{
    public interface IEmployeeSearchable4<T> where T : class, IPersonData4
    {
        IEnumerable<T> GetDataByGenderAndPosition(Gender gender, Position position);

        // Den nye generiske søge-metode
        IEnumerable<T> SearchData(Expression<Func<T, bool>> filter);
    }
}
