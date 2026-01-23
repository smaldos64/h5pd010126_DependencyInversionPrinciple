using DependencyInversionPrinciple.Enums;
using DependencyInversionPrinciple.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversionPrinciple.Models
{
    public class PersonStatistics3<T> where T : class, IPersonData3
    {
        // Vi gemmer en reference til interfacet, ikke til T
        private readonly IEmployeeSearchable3<T> _searchable;

        // Konstruktøren tager imod manageren via interfacet
        public PersonStatistics3(IEmployeeSearchable3<T> searchable)
        {
            _searchable = searchable;
        }

        public int CountFemaleManagers() =>
            _searchable.GetDataByGenderAndPosition(Gender.Female, Position.Manager).Count();
    }
}
