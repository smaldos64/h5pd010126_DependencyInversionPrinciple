using DependencyInversionPrinciple.Enums;
using DependencyInversionPrinciple.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversionPrinciple.Models
{
    public class EmployeeManager5<T> : IEmployeeSearchable5<T> where T : class, IPersonData5
    {
        private readonly List<T> _persons;

        public EmployeeManager5()
        {
            _persons = new List<T>();
        }

        public void AddPerson(T person)
        {
            _persons.Add(person);
        }

        public IEnumerable<T> GetDataByGenderAndPosition(Gender gender, Position position)
            => _persons.Where(emp => emp.Gender == gender && emp.Position == position);

        // Implementering af Expression-søgningen
        public IEnumerable<T> SearchData(Expression<Func<T, bool>> filter)
        {
            // Vi bruger AsQueryable for at kunne håndtere Expression træet
            return _persons.AsQueryable().Where(filter).ToList();
        }
    }
}
