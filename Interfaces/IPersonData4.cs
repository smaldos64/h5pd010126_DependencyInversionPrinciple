using DependencyInversionPrinciple.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversionPrinciple.Interfaces
{
    public interface IPersonData4
    {
        Gender Gender { get; set; }
        Position Position { get; set; }
    }
}
