using System;
using System.Collections.Generic;
using System.IO;

namespace StudentManagementSystem.Library
{
    public class StudentDataRepository
    {
        private List<Student> _listOfStudents;
        private FileInfo _dataFile = new FileInfo(@"D:\data.txt");

        public List<Student> StudentsList
        {
            set
            {
                _listOfStudents = value;
            }
            get
            {
                return _listOfStudents;
            }

        }

        /// <summary>
        /// hardcoded data in repo
        /// </summary>
        public void GetData()
        {
            List<SubjectSelectionRepository> subjectsOfStudent1 = new List<SubjectSelectionRepository>() { SubjectSelectionRepository.English, SubjectSelectionRepository.Geography, SubjectSelectionRepository.German };
            Student student1 = new Student(10, 101, "Alex", 15, 5.8, "Pimple Gurav", subjectsOfStudent1);

            List<SubjectSelectionRepository> subjectsOfStudent2 = new List<SubjectSelectionRepository>() { SubjectSelectionRepository.German, SubjectSelectionRepository.Hindi, SubjectSelectionRepository.History, SubjectSelectionRepository.Marathi };
            Student student2 = new Student(8, 102, "Stacy", 13, 5.5, "Chinchwad", subjectsOfStudent2);


            List<SubjectSelectionRepository> subjectsOfStudent3 = new List<SubjectSelectionRepository>() { SubjectSelectionRepository.History };
            Student student3 = new Student(9, 103, "Max", 14, 5.6, "Koregoan Park", subjectsOfStudent3);

            List<SubjectSelectionRepository> subjectsOfStudent4 = new List<SubjectSelectionRepository>() { SubjectSelectionRepository.Maths, SubjectSelectionRepository.Science };
            Student student4 = new Student(7, 104, "Owen", 12, 5.4, "Shivajinagar", subjectsOfStudent4);

            List<SubjectSelectionRepository> subjectsOfStudent5 = new List<SubjectSelectionRepository>() { SubjectSelectionRepository.English, SubjectSelectionRepository.Science };
            Student student5 = new Student(6, 105, "Justin", 11, 5.2, "Kothrud", subjectsOfStudent5);


            _listOfStudents = new List<Student>() { student1, student2, student3, student4, student5 };
        }

        public void ReadDataInsideFile()
        {
            _listOfStudents = new List<Student>();
            if (_dataFile.Exists)
            {
                StreamReader reader = _dataFile.OpenText();
                string str = reader.ReadLine();

                while (!string.IsNullOrEmpty(str))
                {
                    string[] arrayOfUserInput = str.Split(",", StringSplitOptions.TrimEntries);
                    Student addingNewStudent = new Student();

                    addingNewStudent.Standard = int.Parse(arrayOfUserInput[0]);
                    addingNewStudent.RollNo = int.Parse(arrayOfUserInput[1]);
                    addingNewStudent.Name = arrayOfUserInput[2];
                    addingNewStudent.Age = int.Parse(arrayOfUserInput[3]);
                    addingNewStudent.Height = double.Parse(arrayOfUserInput[4]);
                    addingNewStudent.Address = arrayOfUserInput[5];

                    List<SubjectSelectionRepository> listOfSubjects = new List<SubjectSelectionRepository>();

                    for (int i = 6; i < arrayOfUserInput.Length; i++)
                    {
                        string result = arrayOfUserInput[i];

                        var isValid = Enum.TryParse(typeof(SubjectSelectionRepository), result.Trim(), true, out object subject);

                        if (isValid)
                        {
                            listOfSubjects.Add((SubjectSelectionRepository)subject);
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

        public void WriteDataInsideFile(Student addStudent)
        {
            string studentStr = $"{addStudent.Standard}, {addStudent.RollNo}, {addStudent.Name}," +
                      $"{addStudent.Age}, {addStudent.Height}, {addStudent.Address}";

            foreach (SubjectSelectionRepository subject in addStudent.Subjects)
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
