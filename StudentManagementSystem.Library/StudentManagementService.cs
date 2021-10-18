using System;
using System.Collections.Generic;

namespace StudentManagementSystem.Library
{
    public class StudentManagementService
    {
        ValidateInputs _validate = new ValidateInputs();
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

        public List<Student> DisplayAllStudentsData()
        {
            return _studentRepoService.FetchStudents();
        }

        public string GetName(int rollNo)
        {
            foreach (var eachStudent in _studentRepoService.FetchStudents())
            {
                if (rollNo == eachStudent.RollNo)
                {
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
                    return eachStudent;
                }
            }
            throw new Exception();
        }

        public void AddStudent(Student addStudent)
        {
            _studentRepoService.AddStudent(addStudent);
            DisplayAllStudentsData();
        }

        public List<Student> RemoveStudent(int rollNo)
        {
            foreach (var eachStudent in _studentRepoService.FetchStudents())
            {
                if (rollNo == eachStudent.RollNo)
                {
                    _studentRepoService.DeleteStudent(rollNo, eachStudent);
                    return DisplayAllStudentsData();
                }
            }
            throw new Exception();
        }


        public void AddSubject(int rollNo, List<SubjectSelectionRepository> subjects)
        {
            foreach (var eachStudent in _studentRepoService.FetchStudents())
            {
                if (rollNo == eachStudent.RollNo)
                {
                    eachStudent.AddingSubject(subjects);
                    _studentRepoService.UpdateStudent(rollNo,eachStudent);
                    break;
                }
            }

            DisplayAllStudentsData();
        }


        public void RemoveSubject(int rollNo, List<SubjectSelectionRepository> subjects)
        {
            foreach (var eachStudent in _studentRepoService.FetchStudents())
            {
                if (rollNo == eachStudent.RollNo)
                {
                    eachStudent.RemovingSubject(subjects);
                    _studentRepoService.DeleteStudent(rollNo, eachStudent);
                    break;
                }
            }

            DisplayAllStudentsData();
        }

        //public void RemoveSubject(int rollNo)
        //{
        //    foreach (var eachStudent in _studentRepoService.FetchStudents())
        //    {
        //        if (rollNo == eachStudent.RollNo)
        //        {
        //            Console.WriteLine("\nEnter Subjects seperated by ','");
        //            Console.Write($"Enter Subjects: ");

        //            eachStudent.RemovingSubject(_validate.GetSubjectInput());
        //            break;
        //        }
        //    }

        //    DisplayAllStudentsData();
        //}

    }
}
