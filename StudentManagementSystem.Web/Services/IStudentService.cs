using StudentManagementSystem.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.Web.Services
{
    public interface IStudentService
    {
        Task<List<Student>> FetchStudents();
        Task<Student> GetStudentName(int rollNo);
        Task<Student> GetStudentRollNo(string name);
        Task<Student> GetStudentDetails(int rollNo);
        void AddStudent(Student addStudent);

        void UpdateStudent(int rollNo, Student student);

        void DeleteStudent(int rollNo, Student removeStudent);
    }
}
