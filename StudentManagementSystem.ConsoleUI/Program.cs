using StudentManagementSystem.Library;
using System;

namespace StudentManagementSystem.ConsoleUI
{
    class Program
    {
        static StudentManagementService _services;
        static ValidateInputs _validate = new ValidateInputs();
        static IStudentRepoService studentRepoService = new StudentFileRepoService();

        static void Main(string[] args)
        {
            _services = new StudentManagementService(studentRepoService);
            OperateMenuOptions();
        }

        static void OperateMenuOptions()
        {
            char exitApplication;
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

                int selectedOption = _validate.GetIntegerInput();
                PerformMenuOperation(selectedOption);

                if (selectedOption == 9)
                {
                    exitApplication = 'y';
                }
                else
                {
                    ExitApplication();
                    exitApplication = Convert.ToChar(Console.ReadLine().Trim().ToLower());
                }
                while (exitApplication != 'n' && exitApplication != 'y')
                {
                    Console.WriteLine("Invalid input, please try again....!!");
                    ExitApplication();
                    exitApplication = Convert.ToChar(Console.ReadLine().Trim().ToLower());
                }

            } while (exitApplication == 'n');
            Console.WriteLine("Application Terminated");
        }

        static void PerformMenuOperation(int menuInput)
        {
            switch (menuInput)
            {
                case 1:
                    DisplayStudents();
                    break;
                case 2:
                    GetStudentName();
                    break;
                case 3:
                    GetStudentRollNo();
                    break;
                case 4:
                    GetStudentDetails();
                    break;
                case 5:
                    AddNewStudent();
                    break;
                case 6:
                    RemoveStudent();
                    break;
                case 7:
                    Console.Write("\nEnter Roll No: ");
                    var userInputCase7 = _validate.GetIntegerInput();
                    if (userInputCase7 != default)
                    {
                        _services.AddSubject(userInputCase7);
                    }
                    break;
                case 8:
                    Console.Write("\nEnter Roll No: ");
                    var userInputCase8 = _validate.GetIntegerInput();
                    if (userInputCase8 != default)
                    {
                        _services.RemoveSubject(userInputCase8);
                    }
                    break;
                default:
                    break;
            }
        }

        private static void RemoveStudent()
        {
            char continueSystem = default;
            int userInput;
            do
            {
                Console.Write("\nEnter Roll No: ");
                userInput = _validate.GetIntegerInput();
                if (userInput != default)
                {
                    try
                    {
                        _services.RemoveStudent(userInput);
                        Console.WriteLine($"Student with Roll No: {userInput} deleted");
                        break;
                    }
                    catch
                    {
                        Console.WriteLine($"Student with Roll No: {userInput} not found");
                    }
                }
                ContinueOperationInputs();
                continueSystem = Convert.ToChar(Console.ReadLine().Trim().ToLower());

                if (continueSystem == 'n')
                {
                    Console.WriteLine("Operation terminated....!!");
                    break;
                }
                while (continueSystem != 'n' && continueSystem != 'y')
                {
                    Console.WriteLine("Invalid input, please try again....!!");
                    ContinueOperationInputs();
                    continueSystem = Convert.ToChar(Console.ReadLine().Trim().ToLower());
                }

            }
            while (userInput == default || continueSystem == 'y');
        }

        private static void AddNewStudent()
        {
            Console.Write("\nEnter Student Details\n");

            Student addStudent = new Student();

            do
            {
                Console.Write("\nEnter Standard: ");
                addStudent.Standard = _validate.GetIntegerInput();
            } while (addStudent.Standard == default);

            do
            {
                Console.Write("\nEnter Roll No: ");
                addStudent.RollNo = _validate.GetIntegerInput();
            } while (addStudent.RollNo == default); ;

            do
            {
                Console.Write("\nEnter Name: ");
                addStudent.Name = _validate.GetName();
            } while (addStudent.Name == default);

            do
            {
                Console.Write("\nEnter Age: ");
                addStudent.Age = _validate.GetIntegerInput();
            }
            while (addStudent.Age == default);

            do
            {
                Console.Write("\nEnter Height: ");
                addStudent.Height = _validate.GetDoubleFloatInput();
            }
            while (addStudent.Height == default);

            do
            {
                Console.Write("\nEnter Address: ");
                addStudent.Address = _validate.GetAddress();
            }
            while (addStudent.Address == default);

            do
            {
                Console.WriteLine("\nEnter Subjects seperated by ','");
                Console.Write($"Enter Subjects: ");
                addStudent.Subjects = _validate.GetSubjectInput();
            }
            while (addStudent.Subjects == default);

            if (addStudent.Standard != default && addStudent.RollNo != default && addStudent.Name != default && addStudent.Age != default && addStudent.Height != default && addStudent.Address != default && addStudent.Subjects != default)
            {
                _services.AddStudent(addStudent);
                DisplayStudents();
            }
        }

        private static void DisplayStudents()
        {
            var allStudents = _services.DisplayAllStudentsData();

            foreach (var eachStudent in allStudents)
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

        private static void GetStudentRollNo()
        {
            char continueSystem;
            string userInput;
            int studentRollNo = default;
            do
            {
                Console.Write("\nEnter Student Name: ");
                userInput = _validate.GetName();
                if (userInput != default)
                {
                    try
                    {
                        studentRollNo = _services.GetRollNo(userInput);
                        Console.WriteLine("Roll No: {0}", studentRollNo);
                        break;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine($"Student with Name: {userInput} not found");
                    }
                }
                ContinueOperationInputs();
                continueSystem = Convert.ToChar(Console.ReadLine().Trim().ToLower());
                if (continueSystem == 'n')
                {
                    Console.WriteLine("Operation terminated....!!");
                    break;
                }
                while (continueSystem != 'n' && continueSystem != 'y')
                {
                    Console.WriteLine("Invalid input, please try again....!!");
                    ContinueOperationInputs();
                    continueSystem = Convert.ToChar(Console.ReadLine().Trim().ToLower());
                }
            }
            while (userInput == default || studentRollNo == default || continueSystem == 'y');
        }

        private static void GetStudentName()
        {
            char continueSystem;
            int userInput;
            string studentName = null;
            do
            {
                Console.Write("\n\nEnter Roll No: ");
                userInput = _validate.GetIntegerInput();
                if (userInput != default)
                {
                    try
                    {
                        studentName = _services.GetName(userInput);
                        Console.WriteLine("Student Name: {0}", studentName);
                        break;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine($"Student with Roll No: {userInput} not found");
                    }
                }
                ContinueOperationInputs();
                continueSystem = Convert.ToChar(Console.ReadLine().Trim().ToLower());
                if (continueSystem == 'n')
                {
                    Console.WriteLine("Operation terminated....!!");
                    break;
                }
                while (continueSystem != 'n' && continueSystem != 'y')
                {
                    Console.WriteLine("Invalid input, please try again....!!");
                    ContinueOperationInputs();
                    continueSystem = Convert.ToChar(Console.ReadLine().Trim().ToLower());
                }
            }
            while (userInput == default || studentName == null || continueSystem == 'y');
        }

        private static void GetStudentDetails()
        {
            char continueSystem;
            int userInput;
            Student studentDetails = default;
            do
            {
                Console.Write("\nTo Get All Details Of Student Please Enter Roll No: ");
                userInput = _validate.GetIntegerInput();
                if (userInput != default)
                {
                    try
                    {
                        studentDetails = _services.GetDetailsOfSingleStudent(userInput);

                        Console.Write($"\nStandard: {studentDetails.Standard}\tRoll No: {studentDetails.RollNo}\tName: {studentDetails.Name}\t" +
                        $"Age: {studentDetails.Age}\tHeight: {studentDetails.Height}\tAddress: {studentDetails.Address}\t" +
                        $"Subjects: ");

                        foreach (var eachSubject in studentDetails.Subjects)
                        {
                            Console.Write($"{eachSubject}, ");
                        }

                        break;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine($"Student with Roll No: {userInput} not found");
                    }
                }
                ContinueOperationInputs();
                continueSystem = Convert.ToChar(Console.ReadLine().Trim().ToLower());
                if (continueSystem == 'n')
                {
                    Console.WriteLine("Operation terminated....!!");
                    break;
                }
                while (continueSystem != 'n' && continueSystem != 'y')
                {
                    Console.WriteLine("Invalid input, please try again....!!");
                    ContinueOperationInputs();
                    continueSystem = Convert.ToChar(Console.ReadLine().Trim().ToLower());
                }
            }
            while (userInput == default || studentDetails == default || continueSystem == 'y');
        }

        private static void ContinueOperationInputs()
        {
            Console.WriteLine("\n\nDo you want to re-enter the failed input");
            Console.WriteLine("\nPress (Y/N) for yes or no respectively :");
        }

        private static void ExitApplication()
        {
            Console.WriteLine("\n\nDo you want to exit the application");
            Console.WriteLine("\nPress (Y/N) for yes or no respectively :");
        }


    }
}
