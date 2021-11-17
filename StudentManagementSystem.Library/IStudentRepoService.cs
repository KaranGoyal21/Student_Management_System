using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentManagementSystem.Library
{
    public interface IStudentRepoService
    {
        List<Student> FetchStudents();

        void AddStudent(Student addStudent);

        void UpdateStudent(int rollNo, Student student);

        void DeleteStudent(int rollNo, Student removeStudent);
    }
}
