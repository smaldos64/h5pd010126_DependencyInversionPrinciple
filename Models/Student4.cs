using DependencyInversionPrinciple.Enums;
using DependencyInversionPrinciple.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversionPrinciple.Models
{
    public class Student4 : IPersonData4
    {
        public string? Name { get; set; }
        public Gender Gender { get; set; }
        public Position Position { get; set; }

        public Team Team { get; set; }
    }
}
