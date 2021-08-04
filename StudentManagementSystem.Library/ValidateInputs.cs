using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StudentManagementSystem.Library
{
    public class ValidateInputs
    {
        public int GetIntegerInput()
        {
            string userInput;
            int integerInput;
            do
            {
                userInput = Console.ReadLine().Trim();
                integerInput = default;
                try
                {
                    //bool checkInteger = int.TryParse(str, out num);
                    integerInput = int.Parse(userInput);

                }
                catch (Exception exception)
                {
                    Console.WriteLine("Error: " + exception.Message);
                }

                if (integerInput >= 1)
                {
                    return integerInput;
                }
                else
                {
                    Console.WriteLine("Invalid inputs, please enter positive numbers only");
                    return default;
                }
            }
            while (integerInput != 1);
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


        public string GetName()
        {
            string userInput = Console.ReadLine().Trim();
            string comparisonFormat = "^[a-zA-Z]{1,50}$";
            GetStringInput(userInput, comparisonFormat);

            if (GetStringInput(userInput, comparisonFormat) == true)
            {
                return userInput;
            }
            else
            {
                Console.WriteLine("Invalid inputs, please enter alphabetical characters only");
                return default;
            }
        }

        public string GetAddress()
        {
            string userInput = Console.ReadLine().Trim();
            string comparisonFormat = "^[a-zA-Z0-9-/,@]{1,200}$";
            GetStringInput(userInput, comparisonFormat);

            if (GetStringInput(userInput, comparisonFormat) == true)
            {
                return userInput;
            }
            else
            {
                Console.WriteLine("Invalid inputs, please enter alphabetical characters only");
                return default;
            }
        }

        public bool GetStringInput(string userInput, string comparisonFormat)
        {
            Regex userInputComparison = new Regex(comparisonFormat, RegexOptions.IgnoreCase);
            bool isValid = userInputComparison.IsMatch(userInput);
            return isValid;
        }

        public List<SubjectSelectionRepository> GetSubjectInput()
        {
            string subjectInput = Console.ReadLine().Trim();
            string[] arrayOfSubjectInput = subjectInput.Split(",");

            List<SubjectSelectionRepository> listOfSubjects = new List<SubjectSelectionRepository>();

            foreach (string eachSubject in arrayOfSubjectInput)
            {
                var isValid = Enum.TryParse(typeof(SubjectSelectionRepository), eachSubject.Trim(), true, out object subject);

                if (isValid)
                {
                    listOfSubjects.Add((SubjectSelectionRepository)subject);
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

    }
}
