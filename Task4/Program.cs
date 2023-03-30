using System;
using System.IO;
using System.Collections.Generic;

namespace FinalTask
{
    class Student
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Student(string name, string group, DateTime dateOfBirth)
        {
            Name = name;
            Group = group;
            DateOfBirth = dateOfBirth;
        }
    }

    class Program
    {
        static void Main()
        {
            string binaryFilePath = @"C:\Users\mrvov\Desktop\folder\Students.dat";

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string studentsPath = Path.Combine(desktopPath, "Students");
            Directory.CreateDirectory(studentsPath);

            List<Student> students = new List<Student>();
            using (BinaryReader reader = new BinaryReader(File.Open(binaryFilePath, FileMode.Open)))
            {
                while (reader.PeekChar() > -1)
                {
                    string name = reader.ReadString();
                    string group = reader.ReadString();
                    DateTime dateOfBirth = new DateTime(reader.ReadInt64());
                    students.Add(new Student(name, group, dateOfBirth));
                }
            }

            var groups = students.GroupBy(s => s.Group);
            foreach (var group in groups)
            {
                string groupFilePath = Path.Combine(studentsPath, $"{group.Key}.txt");
                using (StreamWriter writer = new StreamWriter(groupFilePath))
                {
                    foreach (var student in group)
                    {
                        writer.WriteLine($"{student.Name}, {student.DateOfBirth.ToShortDateString()}");
                    }
                }
            }

        }
    }
}
