using System.Collections.Generic;

namespace StudentManagementSystem.Library
{
    public interface IStudentRepoService
    {
        List<Student> FetchStudents();

        void AddStudent(Student addStudent);

        //void UpdateStudent(Student updateStudent);

        void DeleteStudent(Student removeStudent);
    }
}
