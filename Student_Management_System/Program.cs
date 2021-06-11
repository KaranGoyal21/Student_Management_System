using System;
using System.Collections.Generic;

namespace Student_Management_System
{
    class Program
    {
        static List<Student> ListOfStudent;
        static void Main(string[] args)
        {
            FillData();
            DisplayMenu();
            

        }

        public static void DisplayMenu()
        {
            int continueSystem;
            do
            {
                Console.Clear();
                Console.WriteLine("Select desired operation");
                Console.WriteLine("1. Display Students");
                Console.WriteLine("2. Display Student Name");
                Console.WriteLine("3. Display Student Roll No.");
                Console.WriteLine("4. Display Student Details");
                Console.WriteLine("5. Add Student");
                Console.WriteLine("6. Remove Student");
                Console.WriteLine("7. Add Subject");
                Console.WriteLine("8. Remove Subject");
                Console.WriteLine("9. Exit");
                Console.Write("Operation Input: ");

                int menuInput = int.Parse(Console.ReadLine());
                switch (menuInput)
                {
                    case 1:
                        {
                            //Console.Clear();
                            DisplayAll();
                            break;
                        }
                    case 2:
                        {
                            //Console.Clear();
                            Console.Write("\n\nEnter Roll No: ");
                            GetName(int.Parse(Console.ReadLine()));
                            break;
                        }
                    case 3:
                        {
                            //Console.Clear();
                            Console.Write("\nEnter Student Name: ");
                            GetRollNo(Console.ReadLine());
                            break;
                        }
                    case 4:
                        {
                            //Console.Clear();
                            Console.Write("\nTo Get All Details Of Student Please Enter Roll No: ");
                            GetAllDetailOfSingleStudent(int.Parse(Console.ReadLine()));
                            break;
                        }
                    case 5:
                        {
                            //Console.Clear();
                            Console.Write("\nEnter Student Details\n");
                            AddStudent();
                            break;
                        }
                    case 6:
                        {
                            //Console.Clear();
                            Console.Write("\nEnter Roll No: ");
                            RemoveStudent(int.Parse(Console.ReadLine()));
                            break;
                        }
                    case 7:
                        {
                            //Console.Clear();
                            Console.Write("\nEnter Roll No: ");
                            AddSub(int.Parse(Console.ReadLine()));
                            break;
                        }
                    case 8:
                        {
                            //Console.Clear();
                            Console.Write("\nEnter Roll No: ");
                            RemoveSub(int.Parse(Console.ReadLine()));
                            break;
                        }
                    case 9:
                        {
                            Console.WriteLine("Application Terminated");
                            break;
                        }
                    default:
                        break;
                }
                ContinueOperation();
                continueSystem = Convert.ToChar(Console.ReadLine().ToLower());
            } while (continueSystem == 'y');
        }

        static void ContinueOperation()
        {
            Console.WriteLine("\n\nDo you want to continue");
            Console.WriteLine("\nPress Y for yes :");
            Console.WriteLine("Press N for no :");
        }

        public static void FillData()
        {
            List<Subject> subsS1 = new List<Subject>() { Subject.English, Subject.Geography, Subject.German };
            Student s1 = new Student(10, 101, "Alex", 15, 5.8, "Pimple Gurav", subsS1);

            List<Subject> subsS2 = new List<Subject>() { Subject.German, Subject.Hindi, Subject.History, Subject.Marathi };
            Student s2 = new Student(8, 102, "Stacy", 13, 5.5, "Chinchwad", subsS2);


            List<Subject> subsS3 = new List<Subject>() { Subject.History };
            Student s3 = new Student(9, 103, "Max", 14, 5.6, "Koregoan Park", subsS3);

            List<Subject> subsS4 = new List<Subject>() { Subject.Maths, Subject.Science };
            Student s4 = new Student(7, 104, "Owen", 12, 5.4, "Shivajinagar", subsS4);

            List<Subject> subsS5 = new List<Subject>() { Subject.English, Subject.Science };
            Student s5 = new Student(6, 105, "Justin", 11, 5.2, "Kothrud", subsS5);

            ListOfStudent = new List<Student>() { s1, s2, s3, s4, s5 };
        }

        public static void DisplayAll()
        {
            foreach (var data in ListOfStudent)
            {
                Console.Write($"\nStandard: {data.Standard}\tRoll No: {data.RollNo}\tName: {data.Name}\t" +
                    $"Age: {data.Age}\tHeight: {data.Height}\tAddress: {data.Address}\tSubjects: ");

                foreach (var sub in data.Subjects)
                {
                    if (data.Subjects.Count >= 2)
                    {
                        Console.Write($"{sub}, ");
                    }
                    else
                    {
                        Console.Write($"{sub}\t>>>>>>>>>>>>>>>>>>>>>>>>>>(Please Enter Min. Two Subjects)");
                    }
                }
            }
        }

        public static void GetName(int rollNo)
        {
            foreach (var data in ListOfStudent)
            {
                if (rollNo == data.RollNo)
                {
                    Console.WriteLine("Student Name: {0}", data.Name);
                    break;
                }
            }
        }

        public static void GetRollNo(string name)
        {
            foreach (var data in ListOfStudent)
            {
                if (name == data.Name)
                {
                    Console.WriteLine("Roll No: {0}", data.RollNo);
                    break;
                }
            }
        }

        public static void GetAllDetailOfSingleStudent(int rollNo)
        {
            foreach (var data in ListOfStudent)
            {
                if (rollNo == data.RollNo)
                {
                    Console.Write($"\nStandard: {data.Standard}\tRoll No: {data.RollNo}\tName: {data.Name}\t" +
                    $"Age: {data.Age}\tHeight: {data.Height}\tAddress: {data.Address}\t" +
                    $"Subjects: ");

                    foreach (var sub in data.Subjects)
                    {
                        Console.Write($"{sub}, ");
                    }

                    Console.WriteLine();
                    break;
                }
            }
        }

        public static void AddStudent()
        {
            Student sX = new Student();
            Console.Write("Enter Standard: ");
            sX.Standard = int.Parse(Console.ReadLine());
            Console.Write("\nEnter Roll No: ");
            sX.RollNo = int.Parse(Console.ReadLine());
            Console.Write("\nEnter Name: ");
            sX.Name = Console.ReadLine().Trim();
            Console.Write("\nEnter Age: ");
            sX.Age = int.Parse(Console.ReadLine());
            Console.Write("\nEnter Height: ");
            sX.Height = double.Parse(Console.ReadLine());
            Console.Write("\nEnter Address: ");
            sX.Address = Console.ReadLine().Trim();

            Console.WriteLine("\nEnter Subjects seperated by ','");
            Console.Write($"Enter Subjects: ");
            string subs = Console.ReadLine();
            string[] splitSubs = subs.Split(",");

            List<Subject> subjects2 = new List<Subject>();
            foreach (string realsubs in splitSubs)
            {
                var subs1 = (Subject)Enum.Parse(typeof(Subject), realsubs.Trim(), true);
                subjects2.Add(subs1);
            }


            sX.Subjects = subjects2;

            ListOfStudent.Add(sX);

            DisplayAll();
        }

        public static void RemoveStudent(int rollNo)
        {
            foreach (var data in ListOfStudent)
            {
                if (rollNo == data.RollNo)
                {
                    ListOfStudent.Remove(data);
                    break;
                }
            }
            DisplayAll();
        }

        public static void AddSub(int rollNo)
        {
            foreach (var data in ListOfStudent)
            {
                if (rollNo == data.RollNo)
                {
                    Console.WriteLine("\nEnter Subjects seperated by ','");
                    Console.Write($"Enter Subjects: ");
                    string input = Console.ReadLine();
                    string[] arrInput = input.Split(',');
                    List<Subject> sub1 = new List<Subject>();
                    foreach (var sub11 in arrInput)
                    {
                        var sub12 = (Subject)Enum.Parse(typeof(Subject), sub11.Trim(), true);
                        sub1.Add(sub12);
                    }
                    data.AddSubject(sub1);
                    break;
                }
            }

            DisplayAll();
        }

        public static void RemoveSub(int rollNo)
        {
            foreach (var data in ListOfStudent)
            {
                if (rollNo == data.RollNo)
                {
                    Console.WriteLine("\nEnter Subjects seperated by ','");
                    Console.Write($"Enter Subjects: ");
                    string input = Console.ReadLine();
                    string[] arrInput = input.Split(',');
                    List<Subject> sub1 = new List<Subject>();
                    foreach (var sub11 in arrInput)
                    {
                        var sub12 = (Subject)Enum.Parse(typeof(Subject), sub11.Trim(), true);
                        sub1.Add(sub12);
                    }
                    data.RemoveSubject(sub1);
                    break;
                }
            }

            DisplayAll();
        }

    }
}
