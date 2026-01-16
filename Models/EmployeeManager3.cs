using DependencyInversionPrinciple.Enums;
using DependencyInversionPrinciple.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversionPrinciple.Models
{
    public class EmployeeManager3<T> : IEmployeeSearchable3<T> where T : class, IPersonData3
    {
        private readonly List<T> _persons;

        public EmployeeManager3()
        {
            _persons = new List<T>();
        }

        public void AddPerson(T person)
        {
            _persons.Add(person);
        }

        public IEnumerable<T> GetDataByGenderAndPosition(Gender gender, Position position)
            => _persons.Where(emp => emp.Gender == gender && emp.Position == position);
    }
}
