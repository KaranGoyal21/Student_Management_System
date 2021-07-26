using System;

namespace Student_Management_System
{
    class Program
    {
        static StudentManagementService services = new StudentManagementService();
        static ValidateInputs validate = new ValidateInputs();

        static void Main(string[] args)
        {
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

                int selectedOption = int.Parse(Console.ReadLine());
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
                    services.DisplayAllStudentsData();
                    break;
                case 2:
                    Console.Write("\n\nEnter Roll No: ");
                    var userInputCase2 = validate.GetIntegerInput();
                    if (userInputCase2 != default)
                    {
                        services.GetName(userInputCase2);
                    }
                    break;
                case 3:
                    Console.Write("\nEnter Student Name: ");
                    var userInputCase3 = validate.GetName();
                    if (userInputCase3 != default)
                    {
                        services.GetRollNo(userInputCase3);
                    }
                    break;
                case 4:
                    Console.Write("\nTo Get All Details Of Student Please Enter Roll No: ");
                    var userInputCase4 = validate.GetIntegerInput();
                    if (userInputCase4 != default)
                    {
                        services.GetDetailsOfSingleStudent(userInputCase4);
                    }
                    break;
                case 5:
                    Console.Write("\nEnter Student Details\n");
                    services.AddingStudent();
                    break;
                case 6:
                    Console.Write("\nEnter Roll No: ");
                    var userInputCase6 = validate.GetIntegerInput();
                    if (userInputCase6 != default)
                    {
                        services.RemovingStudent(userInputCase6);
                    }
                    break;
                case 7:
                    Console.Write("\nEnter Roll No: ");
                    var userInputCase7 = validate.GetIntegerInput();
                    if (userInputCase7 != default)
                    {
                        services.AddingSubject(userInputCase7);
                    }
                    break;
                case 8:
                    Console.Write("\nEnter Roll No: ");
                    var userInputCase8 = validate.GetIntegerInput();
                    if (userInputCase8 != default)
                    {
                        services.RemovingSubject(userInputCase8);
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
