using StudentManagementSystem.Library;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentManagementSystem.Web.Services
{
    public interface IStudentService
    {
        Task<List<Student>> FetchStudents();
        Task<Student> GetStudentName(int rollNo);
        Task<Student> GetStudentRollNo(string name);
        Task<Student> GetStudentDetails(int rollNo);
        Task<Student> AddStudent(Student addStudent);

        Task<Student> UpdateStudent(Student student);

        Task DeleteStudent(int rollNo, Student removeStudent);
    }
}
