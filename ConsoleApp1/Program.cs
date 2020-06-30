using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.Json;
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
                
            string path = @"C:\Users\Administrator\Desktop\APBD\tutorial2\ConsoleApp1\file.csv";
            var FileWriter = new FileStream(@"data.xml", FileMode.Create);
            var LogWriter = new FileStream("log.txt", FileMode.Create);

            using (var writer = new StreamWriter(LogWriter))
                try
                {
                    var students = new List<Student>();
                    using (var stream = new StreamReader(File.OpenRead(path)))
                    {

                        string line = null;
                        while ((line = stream.ReadLine()) != null)
                        {
                            string[] student = line.Split(',');
                            var stud = new Student
                            {
                                FirstName = student[0],
                                LastName = student[1],
                                Studies = new Studies(student[2], student[3]),
                                StudentNumber = student[4],
                                DateOfBirth = student[5],
                                Email = student[6],
                                MotherName = student[7],
                                FatherName = student[8]
                            };
                            students.Add(stud);
                        }
                        var uni = new University
                        {
                            CreatedAt = DateTime.Now.ToString("dd.MM.yyyy", DateTimeFormatInfo.InvariantInfo),
                            Author = "Vlad Kotowski",
                            Students = students
                        };

                        if (args.Length != 3 || !args[2].ToLower().Equals("json"))
                        {
                            var serializer = new XmlSerializer(typeof(University));
                            serializer.Serialize(FileWriter, uni);
                        }
                        else
                        {
                            var UniWrapper = new UniversityHeader { University = uni };
                            var jsonString = JsonSerializer.Serialize(UniWrapper);
                            File.WriteAllText("data.json", jsonString);
                        }
                    }
                }
                catch (FileNotFoundException ex)
                {
                    writer.WriteLine("File does not exists");
                    Log("File does not exists");
                }
                catch (ArgumentException ex)
                {
                    writer.WriteLine("The path is incorrect");
                    Log("The path is incorrect");
                }
        }
    }
}   