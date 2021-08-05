using StudentManagementSystem.Library;
using System;

namespace StudentManagementSystem.ConsoleUI
{
    class Program
    {
        static StudentManagementService _services;
        static ValidateInputs _validate = new ValidateInputs();
        static IStudentRepoService studentRepoService = new StudentRepoService();

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
                    _services.DisplayAllStudentsData();
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
                    Console.Write("\nEnter Student Details\n");
                    _services.AddStudent();
                    break;
                case 6:
                    Console.Write("\nEnter Roll No: ");
                    var userInputCase6 = _validate.GetIntegerInput();
                    if (userInputCase6 != default)
                    {
                        _services.RemoveStudent(userInputCase6);
                    }
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
