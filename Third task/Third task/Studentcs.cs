using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Third_task
{
    class Student: IComparable
    {
        public string Name { get; set; }
        public int Testmark { get; set; }
        public string Testname { get; set; }

      
        public Student(string name,string testname,int testmark)
        {
            Name = name;
            Testname = testname;
            Testmark = testmark;
        }
        public Student (int testmark)
        {
            Testmark = testmark;
        }
        public override string ToString()
        {
            return string.Format($"{Name} {Testname}: {Testmark}");
        }

        public int CompareTo(object obj)
        {
            Student ex = obj as Student;
            return Testmark.CompareTo(ex.Testmark);
        }
    }
}
