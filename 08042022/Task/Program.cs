using System;
using System.Collections.Generic;

namespace Task
{
    //delegate bool SearchDelegate(Student std);
    internal class Program
    {
        static void Main(string[] args)
        {
            Student studen1 = new Student("Hikmet", 56);
            Student studen2 = new Student("Abbas", 66);
            Student studen3 = new Student("Nigar", 46);
            Student studen4 = new Student("Rustem", 86);
            Student studen5 = new Student("Tofiq", 96);

            Group group = new Group();
            group.Students.Add(studen1);
            group.Students.Add(studen2);
            group.Students.Add(studen3);
            group.Students.Add(studen4);
            group.Students.Add(studen5);

            var wantedStudnets = group.Search(x => x.FullName.Length>5);
            wantedStudnets = group.Search(delegate(Student std) { return std.Point > 65; });
            wantedStudnets = group.Search(IsPassed);



            foreach (var item in wantedStudnets)
            {
                Console.WriteLine(item.FullName+" - "+item.Point);
            }


            Employee employee1 = new Employee
            {
                Salary = 1000
            };
            Employee employee2 = new Employee
            {
                Salary = 1500
            };
            Employee employee3 = new Employee
            {
                Salary = 2500
            };
            Employee employee4 = new Employee
            {
                Salary = 800
            };

            Company company = new Company();
            company.Employees.Add(employee1);
            company.Employees.Add(employee2);
            company.Employees.Add(employee3);
            company.Employees.Add(employee4);

            Console.WriteLine(company.Exists(x=>x.Salary>4000));

            Console.WriteLine(company.Employees.Exists(x=>x.Salary>4000));

            foreach (var item in company.Employees.FindAll(x=>x.Salary>1000))
            {
                Console.WriteLine(item.Salary);
            }

            List<int> nums = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            foreach (var item in nums.FindAll(delegate(int num) { return num % 2 == 0; }))
            {
                Console.WriteLine(item);
            }

            var firstEvenNum = nums.Find(x => x % 2 == 0);
            Console.WriteLine("firstEvenNum: "+firstEvenNum);

            Console.WriteLine(nums.Exists(x=>x>5));

        }

        static bool IsPassed(Student student)
        {
            return student.Point > 50;
        }
    }
}
