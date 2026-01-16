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
    public class PersonStatistics4<T> where T : class, IPersonData4
    {
        // Vi gemmer en reference til interfacet, ikke til T
        private readonly IEmployeeSearchable4<T> _searchable;

        // Konstruktøren tager imod manageren via interfacet
        public PersonStatistics4(IEmployeeSearchable4<T> searchable)
        {
            _searchable = searchable;
        }

        public int CountFemaleManagers() =>
            _searchable.GetDataByGenderAndPosition(Gender.Female, Position.Manager).Count();

        public int CountData(Expression<Func<T, bool>> filter) =>
            _searchable.SearchData(filter).Count(); 
    }
}
