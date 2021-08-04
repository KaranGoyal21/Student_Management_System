using System;
using System.Collections.Generic;
using System.IO;

namespace StudentManagementSystem.Library
{
    public class StudentRepoService : IStudentRepoService
    {
        List<Student> _listOfStudents;
        private FileInfo _dataFile = new FileInfo(@"D:\study\study\projects\Student_Management_System\StudentManagementSystem.Library\Data File\data.txt");

        public void DeleteDataInsideFile(Student removeStudent)
        {
            _listOfStudents?.Remove(removeStudent);
        }
        public List<Student> ReadDataInsideFile()
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
            return _listOfStudents;
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
