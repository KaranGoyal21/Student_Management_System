using StudentManagementSystem.Library;
using System;

namespace StudentManagementSystem.ConsoleUI
{
    class Program
    {
        static StudentManagementService _services;
        static ValidateInputs _validate = new ValidateInputs();
        static IStudentRepoService x = new StudentRepoService();

        static void Main(string[] args)
        {
            _services = new StudentManagementService(x);
            OperateMenuOptions();
        }

        static void OperateMenuOptions()
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

                int selectedOption = _validate.GetIntegerInput();
                PerformMenuOperation(selectedOption);

                if (selectedOption == 9)
                {
                    continueSystem = 'n';
                }
                else
                {
                    ContinueOperation();
                    continueSystem = Convert.ToChar(Console.ReadLine().Trim().ToLower());
                }

            } while (continueSystem == 'y');

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
                    Console.Write("\n\nEnter Roll No: ");
                    var userInputCase2 = _validate.GetIntegerInput();
                    if (userInputCase2 != default)
                    {
                        _services.GetName(userInputCase2);
                    }
                    break;
                case 3:
                    Console.Write("\nEnter Student Name: ");
                    var userInputCase3 = _validate.GetName();
                    if (userInputCase3 != default)
                    {
                        _services.GetRollNo(userInputCase3);
                    }
                    break;
                case 4:
                    Console.Write("\nTo Get All Details Of Student Please Enter Roll No: ");
                    var userInputCase4 = _validate.GetIntegerInput();
                    if (userInputCase4 != default)
                    {
                        _services.GetDetailsOfSingleStudent(userInputCase4);
                    }
                    break;
                case 5:
                    Console.Write("\nEnter Student Details\n");
                    _services.AddingStudent();
                    break;
                case 6:
                    Console.Write("\nEnter Roll No: ");
                    var userInputCase6 = _validate.GetIntegerInput();
                    if (userInputCase6 != default)
                    {
                        _services.RemovingStudent(userInputCase6);
                    }
                    break;
                case 7:
                    Console.Write("\nEnter Roll No: ");
                    var userInputCase7 = _validate.GetIntegerInput();
                    if (userInputCase7 != default)
                    {
                        _services.AddingSubject(userInputCase7);
                    }
                    break;
                case 8:
                    Console.Write("\nEnter Roll No: ");
                    var userInputCase8 = _validate.GetIntegerInput();
                    if (userInputCase8 != default)
                    {
                        _services.RemovingSubject(userInputCase8);
                    }
                    break;
                default:
                    break;
            }
        }

        static void ContinueOperation()
        {
            Console.WriteLine("\n\nDo you want to continue");
            Console.WriteLine("\nPress Y for yes :");
            Console.WriteLine("Press N for no :");
        }


    }
}
