using DependencyInversionPrinciple.Enums;
using DependencyInversionPrinciple.Interfaces;
using DependencyInversionPrinciple.Models;
using DependencyInversionPrinciple.Tools;
using System.Xml.Linq;

namespace DependencyInversionPrinciple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var empManager1 = new EmployeeManager1();
            empManager1.AddEmployee(new Employee1 { Name = "Leen_1", Gender = Gender.Female, Position = Position.Manager });
            empManager1.AddEmployee(new Employee1 { Name = "Mike_2", Gender = Gender.Male, Position = Position.Administrator });
            var stats1 = new EmployeeStatistics1(empManager1);
            Console.WriteLine($"Number of female managers among Employees (1) is : {stats1.CountFemaleManagers()}");
            Console.WriteLine();

            var empManager2 = new EmployeeManager2();
            empManager2.AddEmployee(new Employee2 { Name = "Leen_2", Gender = Gender.Female, Position = Position.Manager });
            empManager2.AddEmployee(new Employee2 { Name = "Mike_2", Gender = Gender.Male, Position = Position.Administrator });
            empManager2.AddEmployee(new Employee2 { Name = "Helle_2", Gender = Gender.Female, Position = Position.Manager });
            var stats2 = new EmployeeStatistics2(empManager2);
            Console.WriteLine($"Number of female managers among Employees (2) is : {stats2.CountFemaleManagers()}");
            Console.WriteLine();

            EmployeeManager3<Student3> empManager3 = new EmployeeManager3<Student3>();
            empManager3.AddPerson(new Student3 { Name = "Mette_3", Gender = Gender.Female, Position = Position.Manager, Team = Team.h5pd010126 });
            empManager3.AddPerson(new Student3 { Name = "Mike_3", Gender = Gender.Male, Position = Position.Administrator, Team = Team.h5xpd011126 });
            empManager3.AddPerson(new Student3 { Name = "Helle_3", Gender = Gender.Female, Position = Position.Manager, Team = Team.h6pd040126 });
            empManager3.AddPerson(new Student3 { Name = "Hanne_3", Gender = Gender.Female, Position = Position.Manager, Team = Team.h6pd040126 });
            // Linjen herunder kan IKKE compilere
            //empManager3.AddPerson(new Employee3 { Name = "Test_3", Gender = Gender.Female, Position = Position.Manager});
            var stats3 = new PersonStatistics3<Student3>(empManager3);
            Console.WriteLine($"Number of female managers among Students (3) is : {stats3.CountFemaleManagers()}");
            
            EmployeeManager3<Employee3> empManager3_1 = new EmployeeManager3<Employee3>();
            empManager3_1.AddPerson(new Employee3 { Name = "Test_3", Gender = Gender.Female, Position = Position.Manager });
            empManager3_1.AddPerson(new Employee3 { Name = "Test_3_1", Gender = Gender.Female, Position = Position.Manager });
            // Linjen herunder kan IKKE compilere
            //empManager3_1.AddPerson(new Student3 { Name = "Mette_3", Gender = Gender.Female, Position = Position.Manager, Team = Team.h5pd010126 });
            var stats3_1 = new PersonStatistics3<Employee3>(empManager3_1);
            Console.WriteLine($"Number of female managers among Employees (3_1) is : {stats3_1.CountFemaleManagers()}");
            
            EmployeeManager3<IPersonData3> empManager3a = new EmployeeManager3<IPersonData3>();
            empManager3a.AddPerson(new Student3 { Name = "Mette_3", Gender = Gender.Female, Position = Position.Manager, Team = Team.h5pd010126 });
            empManager3a.AddPerson(new Employee3 { Name = "Test_3", Gender = Gender.Female, Position = Position.Manager });
            var stats3_a = new PersonStatistics3<IPersonData3>(empManager3a);
            Console.WriteLine($"Number of female managers among Persons (Employees - Students) (3_2) is : {stats3_a.CountFemaleManagers()}");
            Console.WriteLine();

            EmployeeManager4<Student4> empManager4 = new EmployeeManager4<Student4>();
            empManager4.AddPerson(new Student4 { Name = "Mette_4", Gender = Gender.Female, Position = Position.Manager, Team = Team.h5pd010126 });
            empManager4.AddPerson(new Student4 { Name = "Mike_4", Gender = Gender.Male, Position = Position.Administrator, Team = Team.h5xpd011126 });
            empManager4.AddPerson(new Student4 { Name = "Helle_4", Gender = Gender.Female, Position = Position.Manager, Team = Team.h6pd040126 });
            empManager4.AddPerson(new Student4 { Name = "Hanne_4", Gender = Gender.Female, Position = Position.Manager, Team = Team.h6pd040126 });
            empManager4.AddPerson(new Student4 { Name = "Jette_4", Gender = Gender.Female, Position = Position.Administrator, Team = Team.h6pd040126 });
            var stats4 = new PersonStatistics4<Student4>(empManager4);
            int femaleAndManagersCount = stats4.CountData(s => s.Gender == Gender.Female && s.Position == Position.Manager);
            Console.WriteLine($"Number of female managers among Students (4) is : {femaleAndManagersCount}");
            int femaleOrManagersCount = stats4.CountData(s => s.Gender == Gender.Female || s.Position == Position.Manager);
            Console.WriteLine($"Number of female or managers among Students (4_1) is : {femaleOrManagersCount}");
            Console.WriteLine();

            EmployeeManager5<IPersonData5> empManager5 = new EmployeeManager5<IPersonData5>();
            empManager5.AddPerson(new Student5 { Name = "Mette_5", Gender = Gender.Female, Position = Position.Manager, Team = Team.h5pd010126 });
            empManager5.AddPerson(new Employee5 { Name = "Hans_5", Gender = Gender.Male, Position = Position.Manager });
            var stats5 = new PersonStatistics5<IPersonData5>(empManager5);
            femaleAndManagersCount = stats5.CountData(s => s.Gender == Gender.Female && s.Position == Position.Manager);
            Console.WriteLine($"Number of female and managers among Persons (Employees - Students) (5) is : {femaleAndManagersCount}");
            
            femaleOrManagersCount = stats5.CountData(s => s.Gender == Gender.Female || s.Position == Position.Manager);
            Console.WriteLine($"Number of female or managers among Persons (Employees - Students) (5_1) is : {femaleOrManagersCount}");
            
            int femaleAndManagersCountInStudents = stats5.CountData(s => s is Student5 && s.Position == Position.Manager && s.Gender == Gender.Female);
            Console.WriteLine($"Number of female managers among Students (5_2) is : {femaleAndManagersCountInStudents}");
            
            int maleAndManagersCountInStudents = stats5.CountData(s => s is Student5 && s.Position == Position.Manager && s.Gender == Gender.Male);
            Console.WriteLine($"Number of male managers among Students (5_3) is : {maleAndManagersCountInStudents}");
            
            int numberOfStudentsInList = stats5.CountType<Student5>();
            Console.WriteLine($"Number of Student Objects in List (5_4) is : {numberOfStudentsInList}");
            
            int numberOfEmployeesInList = stats5.CountType<Employee5>();
            Console.WriteLine($"Number of Employees Objects in List (5_5) is : {numberOfEmployeesInList}");
            
            int numberOfPersonsInList = stats5.CountType<IPersonData5>();
            Console.WriteLine($"Number of Persons (Employees - Students) Objects in List (5_6) is : {numberOfPersonsInList}");
            Console.WriteLine();

            List<IPersonData5> iPersondataList = stats5.GetAllData();
            iPersondataList.PrintCollection();
        }
    }
}
