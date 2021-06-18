using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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
            char continueSystem;
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

                int selectOption = MenuInput();

                if (selectOption == 9)
                {
                    continueSystem = 'n';
                }
                else
                {
                    ContinueOperation();
                    continueSystem = Convert.ToChar(Console.ReadLine().ToLower());
                }

            } while (continueSystem == 'y');

            Console.WriteLine("Application Terminated");
        }

        public static int MenuInput()
        {
            int menuInput = int.Parse(Console.ReadLine());
            switch (menuInput)
            {
                case 1:
                        DisplayAll();
                        break;
                case 2:
                        Console.Write("\n\nEnter Roll No: ");
                        var userInputCase2 = IntegerInput();
                        if (userInputCase2 != default)
                        {
                            GetName(userInputCase2);
                        }
                        break;
                case 3:
                        Console.Write("\nEnter Student Name: ");
                        var userInputCase3 = StringInput();
                        if (userInputCase3 != default)
                        {
                            GetRollNo(userInputCase3);
                        }
                        break;
                case 4:
                        Console.Write("\nTo Get All Details Of Student Please Enter Roll No: ");
                        var userInputCase4 = IntegerInput();
                        if (userInputCase4 != default)
                        {
                            GetAllDetailOfSingleStudent(userInputCase4);
                        }
                        break;
                case 5:
                        Console.Write("\nEnter Student Details\n");
                        AddStudent();
                        break;
                case 6:
                        Console.Write("\nEnter Roll No: ");
                        var userInputCase6 = IntegerInput();
                        if (userInputCase6 != default)
                        {
                            RemoveStudent(userInputCase6);
                        }
                        break;
                case 7:
                        Console.Write("\nEnter Roll No: ");
                        var userInputCase7 = IntegerInput();
                        if (userInputCase7 != default)
                        {
                            AddSub(userInputCase7);
                        }
                        break;
                case 8:
                        Console.Write("\nEnter Roll No: ");
                        var userInputCase8 = IntegerInput();
                        if (userInputCase8 != default)
                        {
                            RemoveSub(userInputCase8);
                        }
                        break;
                default:
                    break;
            }
            return menuInput;

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

        public static int IntegerInput()
        {
            string str = Console.ReadLine().Trim();
            int num = default;
            try
            {
                //bool checkInteger = int.TryParse(str, out num);
                num = int.Parse(str);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return num;
        }

        public static string StringInput()
        {
            string input = Console.ReadLine().Trim();
            string parameter = "^[a-zA-Z]{1,50}$";

            Regex reg = new Regex(parameter);
            bool isValid = reg.IsMatch(input);

            if (isValid)
            {
                return input;
            }
            else
            {
                Console.WriteLine("Invalid inputs, please enter alphabetical characters only");
                return default;
            }
        }

        public static List<Subject> SubjectInput()
        {
            string subInput = Console.ReadLine().Trim();
            string[] splitSubjects = subInput.Split(",");

            List<Subject> subjectsList = new List<Subject>();

            foreach (string realSub in splitSubjects)
            {
                var isValid = Enum.TryParse(typeof(Subject), realSub.Trim(), true, out object x);

                if (isValid)
                {
                    subjectsList.Add((Subject)x);
                }
                else
                {
                    Console.WriteLine("Invalid inputs, please enter alphabetical characters only");
                }

                /*try
                {
                    var subject = (Subject)Enum.Parse(typeof(Subject), realsubs.Trim(), true);
                    subjectsList.Add(subject);
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }*/
            }
            return subjectsList;
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
                //if(name.Equals(data.Name,StringComparison.InvariantCultureIgnoreCase))
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
            sX.Standard = IntegerInput();

            Console.Write("\nEnter Roll No: ");
            sX.RollNo = IntegerInput();

            Console.Write("\nEnter Name: ");
            sX.Name = StringInput();

            Console.Write("\nEnter Age: ");
            sX.Age = IntegerInput();

            Console.Write("\nEnter Height: ");
            sX.Height = IntegerInput();

            Console.Write("\nEnter Address: ");
            sX.Address = StringInput();

            Console.WriteLine("\nEnter Subjects seperated by ','");
            Console.Write($"Enter Subjects: ");
            sX.Subjects = SubjectInput();

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
                    
                    data.AddSubject(SubjectInput());
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
                    
                    data.RemoveSubject(SubjectInput());
                    break;
                }
            }

            DisplayAll();
        }

    }
}
