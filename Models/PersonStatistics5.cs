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
    public class PersonStatistics5<T> where T : class, IPersonData5
    {
        // Vi gemmer en reference til interfacet, ikke til T
        private readonly IEmployeeSearchable5<T> _searchable;

        // Konstruktøren tager imod manageren via interfacet
        public PersonStatistics5(IEmployeeSearchable5<T> searchable)
        {
            _searchable = searchable;
        }

        public int CountFemaleManagers() =>
            _searchable.GetDataByGenderAndPosition(Gender.Female, Position.Manager).Count();

        public int CountData(Expression<Func<T, bool>> filter) =>
            _searchable.SearchData(filter).Count();

        // En generisk tæller til specifikke undertyper
        public int CountType<TSub>() where TSub : T =>
            _searchable.SearchData(p => p is TSub).Count();

        public List<T> GetAllData() =>
            _searchable.SearchData(p => true).ToList();

        public List<TSub> GetAllDataOfType<TSub>() where TSub : T =>
            _searchable.SearchData(p => p is TSub).Cast<TSub>().ToList();

        public List<T> GetAllDataByFilter(Expression<Func<T, bool>> filter) =>
            _searchable.SearchData(filter).ToList();
    }
}
