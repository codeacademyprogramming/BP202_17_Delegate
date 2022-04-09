using System;
using System.Collections.Generic;
using System.Text;

namespace Task
{
    internal class Student
    {
        private static int _totalCount;
        public Student(string fullName,int point)
        {
            _totalCount++;
            No = _totalCount;
            FullName = fullName;
            Point = point;
        }
        public int No { get; set; }
        public string FullName { get; set; }
        public int Point { get; set; }
        public string GroupNo { get; set; }

    }
}
