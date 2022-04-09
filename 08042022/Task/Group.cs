using System;
using System.Collections.Generic;
using System.Text;

namespace Task
{
    internal class Group
    {
        public string Name { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
        public List<Student> Search(Predicate<Student> func)
        {
            List<Student> students = new List<Student>();

            foreach (Student student in Students)
            {
                if(func(student))
                        students.Add(student);
            }

            return students;
        }
    }
}
