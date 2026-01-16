using DependencyInversionPrinciple.Enums;
using DependencyInversionPrinciple.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversionPrinciple.Models
{
    public class Employee2 : IPersonData3
    {
        public string? Name { get; set; }
        public Gender Gender { get; set; }
        public Position Position { get; set; }
    }
}
