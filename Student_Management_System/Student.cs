using System;
using System.Collections.Generic;

namespace Student_Management_System
{
    enum Subject
    {
        History = 1,
        Geography,
        Maths,
        English,
        German,
        Marathi,
        Hindi,
        Science
    }
    class Student
    {
        public int Standard { get; set; }
        public int RollNo { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Height { get; set; }
        public string Address { get; set; }
        public List<Subject> Subjects { get; set; }

        public Student()
        { }

        public Student(int standard, int rollNo, string name, int age, double height, string address, List<Subject> subjects)
        {
            this.Standard = standard;
            this.RollNo = rollNo;
            this.Name = name;
            this.Age = age;
            this.Height = height;
            this.Address = address;
            this.Subjects = subjects;
        }

        public Student(string name, int age, int standard)
        {
            this.Name = name;
            this.Age = age;
            this.Standard = standard;
        }

        public Student(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public bool AddSubject(Subject subject)
        {
            bool doesExist = false;
            foreach (var sub in Subjects)
            {
                if (subject == sub)
                {
                    doesExist = true;
                    break;
                }
            }

            if (doesExist)
            {
                Console.WriteLine($"Cannot Add {subject} Subject as it already exists");
                return false;
            }
            else
            {
                this.Subjects.Add(subject);
                Console.WriteLine($"Added {subject} Subject Successfully");
                return true;
            }
        }

        public bool RemoveSubject(Subject subject)
        {
            var doesExists = false;
            foreach (var sub in Subjects)
            {
                if(sub == subject)
                {
                    doesExists = true;
                    break;
                }
            }

            if(doesExists)
            {
                this.Subjects.Remove(subject);
                Console.WriteLine($"{subject} Subject Deleted");
                return true;
            }
            else
            {
                Console.WriteLine($"{subject} Subject Not Found");
                return false;
            }
        }

        public bool AddSubject(List<Subject> subjects)
        {
            foreach(var sub in subjects)
            {
                AddSubject(sub);
            }
            return true;//future implementation of this logic
        }

        public bool RemoveSubject(List<Subject> subjects)
        {
            foreach(var sub in subjects)
            {
                RemoveSubject(sub);
            }
            return true;//future implementation of this logic
        }
    }
}
