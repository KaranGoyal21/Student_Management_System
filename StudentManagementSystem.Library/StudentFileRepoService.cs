using System;
using System.Collections.Generic;
using System.IO;

namespace StudentManagementSystem.Library
{
    public class StudentFileRepoService : IStudentRepoService
    {
        private List<Student> _listOfStudents;
        private const string _dataFilePath = @"D:\study\study\projects\Student_Management_System\StudentManagementSystem.Library\Data File\data.txt";

        public StudentFileRepoService()
        {
            ReadStudentsFromFile();
        }


        public List<Student> FetchStudents()
        {
            return _listOfStudents;
        }

        public void AddStudent(Student addStudent)
        {
            _listOfStudents.Add(addStudent);
            SaveStudentsInFile();
        }

        public void UpdateStudent(Student updateStudent)
        {
            foreach (var student in _listOfStudents)
            {
                if (student.RollNo == updateStudent.RollNo)
                {
                    student.Id = updateStudent.Id;
                    student.Standard = updateStudent.Standard;
                    student.Name = updateStudent.Name;
                    student.Age = updateStudent.Age;
                    student.Height = updateStudent.Height;
                    student.Address = updateStudent.Address;
                    student.Subjects = updateStudent.Subjects;
                }
            }
            SaveStudentsInFile();
        }

        private void SaveStudentsInFile()
        {
            File.Delete(_dataFilePath);
            FileInfo _fileData = new FileInfo(_dataFilePath);
            StreamWriter write = _fileData.CreateText();

            foreach (var student in _listOfStudents)
            {
                string studentStr = $"{student.Standard}, {student.RollNo}, {student.Name}," +
                      $"{student.Age}, {student.Height}, {student.Address}";

                foreach (SubjectSelectionRepository subject in student.Subjects)
                {
                    string result = Convert.ToString(subject);
                    studentStr += $", {subject}";
                }

                write.WriteLine(studentStr);
            }

            write.Close();
        }

        private void ReadStudentsFromFile()
        {
            _listOfStudents = new List<Student>();
            FileInfo _fileData = new FileInfo(_dataFilePath);

            if (_fileData.Exists)
            {
                StreamReader reader = _fileData.OpenText();
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

        public void UpdateStudent(int rollNo, Student student)
        {
            throw new NotImplementedException();
        }

        public void DeleteStudent(int rollNo, Student removeStudent)
        {
            _listOfStudents.Remove(removeStudent);
            SaveStudentsInFile();
        }
    }
}
