using System;
using System.Collections.Generic;

namespace Student_Management_System
{
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

        public bool AddingSubject(Subject subject)
        {
            bool subjectExists = false;
            foreach (var eachSubject in Subjects)
            {
                if (subject == eachSubject)
                {
                    subjectExists = true;
                    break;
                }
            }

            if (subjectExists)
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

        public bool RemovingSubject(Subject subject)
        {
            var subjectExists = false;
            foreach (var eachSubject in Subjects)
            {
                if(eachSubject == subject)
                {
                    subjectExists = true;
                    break;
                }
            }

            if(subjectExists)
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

        public bool AddingSubject(List<Subject> subjects)
        {
            foreach(var sub in subjects)
            {
                AddingSubject(sub);
            }
            return true;//future implementation of this logic
        }

        public bool RemovingSubject(List<Subject> subjects)
        {
            foreach(var sub in subjects)
            {
                RemovingSubject(sub);
            }
            return true;//future implementation of this logic
        }
    }
}
