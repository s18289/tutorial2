using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace ConsoleApp1
{
    [XmlType("student")]
    [XmlInclude(typeof(Studies))]
    [Serializable]
    public class Student
    {

        public Student()
        {

        }

        //public Student(string fname, string lname, string cname, string cmode, string index, string birthdate, string email, string mothersname, string fathersname)
        //{
        //    FirstName = fname;
        //    LastName = lname;
        //    CourseName = cname;
        //    CourseMode = cmode;
        //    IndexNumber = index;
        //    BirthDate = birthdate; 
        //    Email = email;
        //    MothersName = mothersname;
        //    FathersName = fathersname;
        //}

        [XmlElement(ElementName = "fname")]
        [JsonPropertyName("fname")]
        public string FirstName { get; set; }

        [XmlElement(ElementName = "lname")]
        [JsonPropertyName("lname")]
        public string LastName { get; set; }

        [XmlElement(ElementName = "birthdate")]
        [JsonPropertyName("birthdate")]
        public string DateOfBirth { get; set; }

        [XmlElement(ElementName = "email")]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [XmlElement(ElementName = "mothersName")]
        [JsonPropertyName("mothersName")]
        public string MotherName { get; set; }

        [XmlElement(ElementName = "fathersName")]
        [JsonPropertyName("fathersName")]
        public string FatherName { get; set; }

        private string sNumber;
        [XmlAttribute(AttributeName = "indexNumber")]
        [JsonPropertyName("indexNumber")]
        public string StudentNumber
        {
            get
            {
                return sNumber;
            }
            set
            {
                sNumber = $"s{value}";
            }
        }

        [XmlElement(ElementName = "studies")]
        [JsonPropertyName("studies")]
        public Studies Studies { get; set; }
    }
}