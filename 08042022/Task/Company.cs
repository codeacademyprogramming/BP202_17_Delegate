using System;
using System.Collections.Generic;
using System.Text;

namespace Task
{
    internal class Company
    {
        public string Name { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();

        public bool Exists(Predicate<Employee> predicate)
        {
            foreach (var item in Employees)
            {
                if(predicate(item))
                        return true;
            }

            return false;
        }

        public Employee Find(Predicate<Employee> predicate)
        {
            foreach (var item in Employees)
            {
                if (predicate(item))
                    return item;
            }

            return null;
        }

        public List<Employee> FindAll(Predicate<Employee> predicate)
        {
            List<Employee> employees = new List<Employee>();    
            foreach (var item in Employees)
            {
                if (predicate(item))
                    employees.Add(item);
            }

            return employees;
        }


    }
}
