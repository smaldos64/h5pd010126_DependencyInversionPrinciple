using DependencyInversionPrinciple.Enums;
using DependencyInversionPrinciple.Interfaces;
using DependencyInversionPrinciple.Models;
using System.Xml.Linq;

namespace DependencyInversionPrinciple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var empManager1 = new EmployeeManager1();
            empManager1.AddEmployee(new Employee { Name = "Leen", Gender = Gender.Female, Position = Position.Manager });
            empManager1.AddEmployee(new Employee { Name = "Mike", Gender = Gender.Male, Position = Position.Administrator });
            var stats1 = new EmployeeStatistics1(empManager1);
            Console.WriteLine($"Number of female managers in our company(1) is : {stats1.CountFemaleManagers()}");

            var empManager2 = new EmployeeManager2();
            empManager2.AddEmployee(new Employee { Name = "Leen", Gender = Gender.Female, Position = Position.Manager });
            empManager2.AddEmployee(new Employee { Name = "Mike", Gender = Gender.Male, Position = Position.Administrator });
            empManager2.AddEmployee(new Employee { Name = "Helle", Gender = Gender.Female, Position = Position.Manager });
            var stats2 = new EmployeeStatistics2(empManager2);
            Console.WriteLine($"Number of female managers in our company(2) is : {stats2.CountFemaleManagers()}");

            EmployeeManager3<Student3> empManager3 = new EmployeeManager3<Student3>();
            empManager3.AddPerson(new Student3 { Name = "Mette", Gender = Gender.Female, Position = Position.Manager, Team = Team.h5pd010126 });
            empManager3.AddPerson(new Student3 { Name = "Mike", Gender = Gender.Male, Position = Position.Administrator, Team = Team.h5xpd011126 });
            empManager3.AddPerson(new Student3 { Name = "Helle", Gender = Gender.Female, Position = Position.Manager, Team = Team.h6pd040126 });
            empManager3.AddPerson(new Student3 { Name = "Hanne", Gender = Gender.Female, Position = Position.Manager, Team = Team.h6pd040126 });
            var stats3 = new PersonStatistics3<Student3>(empManager3);
            Console.WriteLine($"Number of female managers in our company(3) is : {stats3.CountFemaleManagers()}");

            EmployeeManager4<Student4> empManager4 = new EmployeeManager4<Student4>();
            empManager4.AddPerson(new Student4 { Name = "Mette", Gender = Gender.Female, Position = Position.Manager, Team = Team.h5pd010126 });
            empManager4.AddPerson(new Student4 { Name = "Mike", Gender = Gender.Male, Position = Position.Administrator, Team = Team.h5xpd011126 });
            empManager4.AddPerson(new Student4 { Name = "Helle", Gender = Gender.Female, Position = Position.Manager, Team = Team.h6pd040126 });
            empManager4.AddPerson(new Student4 { Name = "Hanne", Gender = Gender.Female, Position = Position.Manager, Team = Team.h6pd040126 });
            empManager4.AddPerson(new Student4 { Name = "Jette", Gender = Gender.Female, Position = Position.Administrator, Team = Team.h6pd040126 });
            var stats4 = new PersonStatistics4<Student4>(empManager4);
            int femaleManagersCount = stats4.CountData(s => s.Gender == Gender.Female && s.Position == Position.Manager);
            Console.WriteLine($"Number of female managers in our company(4) is : {femaleManagersCount}");
            int femaleOrManagersCount = stats4.CountData(s => s.Gender == Gender.Female || s.Position == Position.Manager);
            Console.WriteLine($"Number of female or managers in our company(5) is : {femaleOrManagersCount}");
        }
    }
}
