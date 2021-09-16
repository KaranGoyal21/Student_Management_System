using System;
using System.Collections.Generic;
using System.IO;

namespace StudentManagementSystem.Library
{
    public class StudentMongoRepoService : IStudentRepoService
    {
        private List<Student> _listOfStudents;

        public StudentMongoRepoService()
        {
        }

        public void DeleteStudent(Student removeStudent)
        {
        }

        public List<Student> FetchStudents()
        {
            return null;
        }

        public void AddStudent(Student addStudent)
        {
        }

    }
}
