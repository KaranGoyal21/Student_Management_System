using System;
using System.Collections.Generic;

namespace StudentManagementSystem.Library
{
    public class StudentManagementService
    {
        ValidateInputs validate = new ValidateInputs();
        readonly IStudentRepoService _studentRepoService;

        public StudentManagementService(IStudentRepoService studentRepoService)
        {
            _studentRepoService = studentRepoService;
        }

        /*public int GetMenuInput()
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

        }*/

        public void DisplayAllStudentsData()
        {
            foreach (var eachStudent in _studentRepoService.FetchStudents())
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

        public string GetName(int rollNo)
        {
            foreach (var eachStudent in _studentRepoService.FetchStudents())
            {
                if (rollNo == eachStudent.RollNo)
                {
                    Console.WriteLine("Student Name: {0}", eachStudent.Name);
                    return eachStudent.Name;
                }
            }
            throw new Exception();
        }

        public int GetRollNo(string name)
        {
            foreach (var eachStudent in _studentRepoService.FetchStudents())
            {
                if (name == eachStudent.Name)
                //if(name.Equals(eachStudent.Name,StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("Roll No: {0}", eachStudent.RollNo);
                    return eachStudent.RollNo;
                }
            }
            throw new Exception();
        }

        public Student GetDetailsOfSingleStudent(int rollNo)
        {
            foreach (var eachStudent in _studentRepoService.FetchStudents())
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
                    return eachStudent;
                }
            }
            throw new Exception();
        }

        public void AddStudent()
        {
            Student addStudent = new Student();

            do
            {
                Console.Write("\nEnter Standard: ");
                addStudent.Standard = validate.GetIntegerInput();
            } while (addStudent.Standard == default);

            do
            {
                Console.Write("\nEnter Roll No: ");
                addStudent.RollNo = validate.GetIntegerInput();
            } while (addStudent.RollNo == default); ;

            do
            {
                Console.Write("\nEnter Name: ");
                addStudent.Name = validate.GetName();
            } while (addStudent.Name == default);

            do
            {
                Console.Write("\nEnter Age: ");
                addStudent.Age = validate.GetIntegerInput();
            }
            while (addStudent.Age == default);

            do
            {
                Console.Write("\nEnter Height: ");
                addStudent.Height = validate.GetDoubleFloatInput();
            }
            while (addStudent.Height == default);

            do
            {
                Console.Write("\nEnter Address: ");
                addStudent.Address = validate.GetAddress();
            }
            while (addStudent.Address == default);

            do
            {
                Console.WriteLine("\nEnter Subjects seperated by ','");
                Console.Write($"Enter Subjects: ");
                addStudent.Subjects = validate.GetSubjectInput();
            }
            while (addStudent.Subjects == default);

            if (addStudent.Standard != default && addStudent.RollNo != default && addStudent.Name != default && addStudent.Age != default && addStudent.Height != default && addStudent.Address != default && addStudent.Subjects != default)
            {
                _studentRepoService.AddStudent(addStudent);
                DisplayAllStudentsData();
            }
        }

        public void RemoveStudent(int rollNo)
        {
            foreach (var eachStudent in _studentRepoService.FetchStudents())
            {
                if (rollNo == eachStudent.RollNo)
                {
                    _studentRepoService.DeleteStudent(eachStudent);
                    break;
                }
            }
            DisplayAllStudentsData();
        }

        public void AddSubject(int rollNo)
        {
            foreach (var eachStudent in _studentRepoService.FetchStudents())
            {
                if (rollNo == eachStudent.RollNo)
                {
                    Console.WriteLine("\nEnter Subjects seperated by ','");
                    Console.Write($"Enter Subjects: ");

                    eachStudent.AddingSubject(validate.GetSubjectInput());
                    break;
                }
            }

            DisplayAllStudentsData();
        }

        public void RemoveSubject(int rollNo)
        {
            foreach (var eachStudent in _studentRepoService.FetchStudents())
            {
                if (rollNo == eachStudent.RollNo)
                {
                    Console.WriteLine("\nEnter Subjects seperated by ','");
                    Console.Write($"Enter Subjects: ");

                    eachStudent.RemovingSubject(validate.GetSubjectInput());
                    break;
                }
            }

            DisplayAllStudentsData();
        }

    }
}
