using System;
using System.Collections.Generic;

namespace Student_Management_System
{
    class Program
    {
        static Student_Management_Services Services = new Student_Management_Services();
        static void Main(string[] args)
        {
            Services.GetData();
            GetDisplayMenu();
        }

        public static void GetDisplayMenu()
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

                int selectOption = GetMenuInput();

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

        public static int GetMenuInput()
        {
            int menuInput = int.Parse(Console.ReadLine());
            switch (menuInput)
            {
                case 1:
                    Services.DisplayAllStudentsData();
                    break;
                case 2:
                    Console.Write("\n\nEnter Roll No: ");
                    var userInputCase2 = Services.GetIntegerInput();
                    if (userInputCase2 != default)
                    {
                        Services.GetName(userInputCase2);
                    }
                    break;
                case 3:
                    Console.Write("\nEnter Student Name: ");
                    var userInputCase3 = Services.GetStringInput();
                    if (userInputCase3 != default)
                    {
                        Services.GetRollNo(userInputCase3);
                    }
                    break;
                case 4:
                    Console.Write("\nTo Get All Details Of Student Please Enter Roll No: ");
                    var userInputCase4 = Services.GetIntegerInput();
                    if (userInputCase4 != default)
                    {
                        Services.GetDetailsOfSingleStudent(userInputCase4);
                    }
                    break;
                case 5:
                    Console.Write("\nEnter Student Details\n");
                    Services.AddingStudent();
                    break;
                case 6:
                    Console.Write("\nEnter Roll No: ");
                    var userInputCase6 = Services.GetIntegerInput();
                    if (userInputCase6 != default)
                    {
                        Services.RemovingStudent(userInputCase6);
                    }
                    break;
                case 7:
                    Console.Write("\nEnter Roll No: ");
                    var userInputCase7 = Services.GetIntegerInput();
                    if (userInputCase7 != default)
                    {
                        Services.AddingSubject(userInputCase7);
                    }
                    break;
                case 8:
                    Console.Write("\nEnter Roll No: ");
                    var userInputCase8 = Services.GetIntegerInput();
                    if (userInputCase8 != default)
                    {
                        Services.RemovingSubject(userInputCase8);
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

    }
}
