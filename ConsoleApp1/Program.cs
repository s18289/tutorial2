using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace ConsoleApp1
{
    class Program
    {

        public static void Log(string message)
        {
            using (StreamWriter writer = new StreamWriter(@"C:\Users\Administrator\Desktop\APBD\task2\ConsoleApp1\log.txt"))
            {
                writer.WriteLine(message);
            }
        }

        static void Main(string[] args)
        {
            string line = null;
            try
            {
                List<Student> list = new List<Student>();
                string path = @"C:\Users\Administrator\Desktop\APBD\task2\ConsoleApp1\file.csv";
                using (var stream = new StreamReader(File.OpenRead(path)))
                while ((line = stream.ReadLine()) != null)
                {
                    string[] students = line.Split(',');

                    if (students.Length < 9)
                    {
                        continue;
                    }

                    var student = new Student
                    {
                        FirstName = students[0],
                        LastName = students[1],
                        CourseName = students[2],
                        CourseMode = students[3],
                        IndexNumber = students[4],
                        BirthDate = students[5],
                        Email = students[6],
                        MothersName = students[7],
                        FathersName = students[8]
                    };
                    list.Add(student);
                }

                FileStream writer = new FileStream(@"data.xml", FileMode.Create);
                XmlSerializer serializer = new XmlSerializer(typeof(List<Student>), new XmlRootAttribute("university"));
                serializer.Serialize(writer, list);
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("File was not found");
                Log("File was not found");
            }
            catch(DirectoryNotFoundException)
            {
                Console.WriteLine("Directory was not found");
                Log("Directory was not found");
            }
        }
    }
}   