using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Student_Management_System
{
    class StudentManagementService
    {
        List<Student> _listOfStudents;
        FileInfo _dataFile = new FileInfo(@"E:\study\study\projects\Projects_Vault\Projects_Vault\Practice Project\file_handling\data.txt");

        public StudentManagementService()
        {
            //GetData();
            ReadDataInsideFile();
        }

        public int GetMenuInput()
        {
            int menuInput = int.Parse(Console.ReadLine());
            switch (menuInput)
            {
                case 1:
                    DisplayAllStudentsData();
                    break;
                case 2:
                    Console.Write("\n\nEnter Roll No: ");
                    var userInputCase2 = GetIntegerInput();
                    if (userInputCase2 != default)
                    {
                        GetName(userInputCase2);
                    }
                    break;
                case 3:
                    Console.Write("\nEnter Student Name: ");
                    var userInputCase3 = GetStringInput();
                    if (userInputCase3 != default)
                    {
                        GetRollNo(userInputCase3);
                    }
                    break;
                case 4:
                    Console.Write("\nTo Get All Details Of Student Please Enter Roll No: ");
                    var userInputCase4 = GetIntegerInput();
                    if (userInputCase4 != default)
                    {
                        GetDetailsOfSingleStudent(userInputCase4);
                    }
                    break;
                case 5:
                    Console.Write("\nEnter Student Details\n");
                    AddingStudent();
                    break;
                case 6:
                    Console.Write("\nEnter Roll No: ");
                    var userInputCase6 = GetIntegerInput();
                    if (userInputCase6 != default)
                    {
                        RemovingStudent(userInputCase6);
                    }
                    break;
                case 7:
                    Console.Write("\nEnter Roll No: ");
                    var userInputCase7 = GetIntegerInput();
                    if (userInputCase7 != default)
                    {
                        AddingSubject(userInputCase7);
                    }
                    break;
                case 8:
                    Console.Write("\nEnter Roll No: ");
                    var userInputCase8 = GetIntegerInput();
                    if (userInputCase8 != default)
                    {
                        RemovingSubject(userInputCase8);
                    }
                    break;
                default:
                    break;
            }
            return menuInput;

        }

        public void GetData()
        {
            List<Subject> subjectsOfStudent1 = new List<Subject>() { Subject.English, Subject.Geography, Subject.German };
            Student student1 = new Student(10, 101, "Alex", 15, 5.8, "Pimple Gurav", subjectsOfStudent1);

            List<Subject> subjectsOfStudent2 = new List<Subject>() { Subject.German, Subject.Hindi, Subject.History, Subject.Marathi };
            Student student2 = new Student(8, 102, "Stacy", 13, 5.5, "Chinchwad", subjectsOfStudent2);


            List<Subject> subjectsOfStudent3 = new List<Subject>() { Subject.History };
            Student student3 = new Student(9, 103, "Max", 14, 5.6, "Koregoan Park", subjectsOfStudent3);

            List<Subject> subjectsOfStudent4 = new List<Subject>() { Subject.Maths, Subject.Science };
            Student student4 = new Student(7, 104, "Owen", 12, 5.4, "Shivajinagar", subjectsOfStudent4);

            List<Subject> subjectsOfStudent5 = new List<Subject>() { Subject.English, Subject.Science };
            Student student5 = new Student(6, 105, "Justin", 11, 5.2, "Kothrud", subjectsOfStudent5);


            _listOfStudents = new List<Student>() { student1, student2, student3, student4, student5 };
        }

        public int GetIntegerInput()
        {
            string userInput = Console.ReadLine().Trim();
            int integerInput = default;
            try
            {
                //bool checkInteger = int.TryParse(str, out num);
                integerInput = int.Parse(userInput);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error: " + exception.Message);
            }
            return integerInput;
        }

        public double GetDoubleFloatInput()
        {
            string userInput = Console.ReadLine().Trim();
            double doubleInput = default;
            try
            {
                doubleInput = double.Parse(userInput);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error: " + exception.Message);
            }
            return doubleInput;
        }

        public string GetStringInput()
        {
            string userInput = Console.ReadLine().Trim();
            string comparisonFormat = "^[a-zA-Z ]{1,50}$";

            Regex userInputComparison = new Regex(comparisonFormat, RegexOptions.IgnoreCase);
            bool isValid = userInputComparison.IsMatch(userInput);

            if (isValid)
            {
                return userInput;
            }
            else
            {
                Console.WriteLine("Invalid inputs, please enter alphabetical characters only");
                return default;
            }
        }

        public List<Subject> GetSubjectInput()
        {
            string subjectInput = Console.ReadLine().Trim();
            string[] arrayOfSubjectInput = subjectInput.Split(",");

            List<Subject> listOfSubjects = new List<Subject>();

            foreach (string eachSubject in arrayOfSubjectInput)
            {
                var isValid = Enum.TryParse(typeof(Subject), eachSubject.Trim(), true, out object subject);

                if (isValid)
                {
                    listOfSubjects.Add((Subject)subject);
                }
                else
                {
                    Console.WriteLine("Invalid inputs, please enter alphabetical characters only");
                }

                /*try
                {
                    var subject = (Subject)Enum.Parse(typeof(Subject), eachSubject.Trim(), true);
                    listOfSubjects.Add(subject);
                }
                catch(Exception exception)
                {
                    Console.WriteLine("Error: " + exception.Message);
                }*/
            }
            return listOfSubjects;
        }

        public void DisplayAllStudentsData()
        {
            foreach (var eachStudent in _listOfStudents)
            {
                Console.Write($"\nStandard: {eachStudent.Standard}\tRoll No: {eachStudent.RollNo}\tName: {eachStudent.Name}\t" +
                    $"Age: {eachStudent.Age}\tHeight: {eachStudent.Height}\tAddress: {eachStudent.Address}\tSubjects: ");

                foreach (var subject in eachStudent.Subjects)
                {
                    if (eachStudent.Subjects.Count >= 2)
                    {
                        Console.Write($"{subject}, ");
                    }
                    else
                    {
                        Console.Write($"{subject}\t>>>>>>>>>>>>>>>>>>>>>>>>>>(Please Enter Min. Two Subjects)");
                    }
                }
            }
        }

        public void GetName(int rollNo)
        {
            foreach (var eachStudent in _listOfStudents)
            {
                if (rollNo == eachStudent.RollNo)
                {
                    Console.WriteLine("Student Name: {0}", eachStudent.Name);
                    break;
                }
            }
        }

        public void GetRollNo(string name)
        {
            foreach (var eachStudent in _listOfStudents)
            {
                if (name == eachStudent.Name)
                //if(name.Equals(eachStudent.Name,StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("Roll No: {0}", eachStudent.RollNo);
                    break;
                }
            }
        }

        public void GetDetailsOfSingleStudent(int rollNo)
        {
            foreach (var eachStudent in _listOfStudents)
            {
                if (rollNo == eachStudent.RollNo)
                {
                    Console.Write($"\nStandard: {eachStudent.Standard}\tRoll No: {eachStudent.RollNo}\tName: {eachStudent.Name}\t" +
                    $"Age: {eachStudent.Age}\tHeight: {eachStudent.Height}\tAddress: {eachStudent.Address}\t" +
                    $"Subjects: ");

                    foreach (var eachSubject in eachStudent.Subjects)
                    {
                        Console.Write($"{eachSubject}, ");
                    }

                    Console.WriteLine();
                    break;
                }
            }
        }

        public void AddingStudent()
        {
            Student addStudent = new Student();

            Console.Write("Enter Standard: ");
            addStudent.Standard = GetIntegerInput();

            Console.Write("\nEnter Roll No: ");
            addStudent.RollNo = GetIntegerInput();

            Console.Write("\nEnter Name: ");
            addStudent.Name = GetStringInput();

            Console.Write("\nEnter Age: ");
            addStudent.Age = GetIntegerInput();

            Console.Write("\nEnter Height: ");
            addStudent.Height = GetDoubleFloatInput();

            Console.Write("\nEnter Address: ");
            addStudent.Address = GetStringInput();

            Console.WriteLine("\nEnter Subjects seperated by ','");
            Console.Write($"Enter Subjects: ");
            addStudent.Subjects = GetSubjectInput();

            _listOfStudents.Add(addStudent);
            DisplayAllStudentsData();

            WriteDataInsideFile(addStudent);
        }

        public void RemovingStudent(int rollNo)
        {
            foreach (var eachStudent in _listOfStudents)
            {
                if (rollNo == eachStudent.RollNo)
                {
                    _listOfStudents.Remove(eachStudent);
                    break;
                }
            }
            DisplayAllStudentsData();
        }

        public void AddingSubject(int rollNo)
        {
            foreach (var eachStudent in _listOfStudents)
            {
                if (rollNo == eachStudent.RollNo)
                {
                    Console.WriteLine("\nEnter Subjects seperated by ','");
                    Console.Write($"Enter Subjects: ");

                    eachStudent.AddingSubject(GetSubjectInput());
                    break;
                }
            }

            DisplayAllStudentsData();
        }

        public void RemovingSubject(int rollNo)
        {
            foreach (var eachStudent in _listOfStudents)
            {
                if (rollNo == eachStudent.RollNo)
                {
                    Console.WriteLine("\nEnter Subjects seperated by ','");
                    Console.Write($"Enter Subjects: ");

                    eachStudent.RemovingSubject(GetSubjectInput());
                    break;
                }
            }

            DisplayAllStudentsData();
        }

        public void ReadDataInsideFile()
        {
            _listOfStudents = new List<Student>();
            if (_dataFile.Exists)
            {
                StreamReader reader = _dataFile.OpenText();
                string str = reader.ReadLine();


                while (str != null)
                {
                    string[] arrayOfUserInput = str.Split(",", StringSplitOptions.TrimEntries);
                    Student addingNewStudent = new Student();

                    addingNewStudent.Standard = int.Parse(arrayOfUserInput[0]);
                    addingNewStudent.RollNo = int.Parse(arrayOfUserInput[1]);
                    addingNewStudent.Name = arrayOfUserInput[2];
                    addingNewStudent.Age = int.Parse(arrayOfUserInput[3]);
                    addingNewStudent.Height = double.Parse(arrayOfUserInput[4]);
                    addingNewStudent.Address = arrayOfUserInput[5];

                    List<Subject> listOfSubjects = new List<Subject>();

                    for (int i = 6; i < arrayOfUserInput.Length; i++)
                    {
                        string result = arrayOfUserInput[i];

                        var isValid = Enum.TryParse(typeof(Subject), result.Trim(), true, out object subject);

                        if (isValid)
                        {
                            listOfSubjects.Add((Subject)subject);
                        }
                        else
                        {
                            Console.WriteLine("Invalid inputs, please enter alphabetical characters only");
                        }

                    }

                    addingNewStudent.Subjects = listOfSubjects;

                    _listOfStudents.Add(addingNewStudent);

                    str = reader.ReadLine();
                }

                reader.Close();

            }
            else
            {
                Console.WriteLine("File does not exist");
            }
        }

        private void WriteDataInsideFile(Student addStudent)
        {
            string studentStr = $"{addStudent.Standard}, {addStudent.RollNo}, {addStudent.Name}," +
                      $"{addStudent.Age}, {addStudent.Height}, {addStudent.Address}";

            foreach (Subject subject in addStudent.Subjects)
            {
                string result = Convert.ToString(subject);
                studentStr += $", {subject}";
            }

            StreamWriter write;
            if (_dataFile.Exists)
            {
                write = _dataFile.AppendText();
            }
            else
            {
                write = _dataFile.CreateText();
            }

            write.WriteLine(studentStr);
            write.Close();
        }
    }
}
