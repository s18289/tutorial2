using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    [Serializable]
    public class Student
    {

        public Student()
        {

        }
        public Student(string fname, string lname, string cname, string cmode, string index, string birthdate, string email, string mothersname, string fathersname)
        {
            FirstName = fname;
            LastName = lname;
            CourseName = cname;
            CourseMode = cmode;
            IndexNumber = index;
            BirthDate = birthdate; 
            Email = email;
            MothersName = mothersname;
            FathersName = fathersname;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CourseName { get; set; }
        public string CourseMode { get; set; }
        public string IndexNumber { get; set; }
        public string BirthDate { get; set; }
        public string Email { get; set; }
        public string MothersName { get; set; }
        public string FathersName { get; set; }
    }
}