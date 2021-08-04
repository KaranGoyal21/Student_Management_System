using System.Collections.Generic;

namespace StudentManagementSystem.Library
{
    public interface IStudentRepoService
    {
        List<Student> ReadDataInsideFile();

        void WriteDataInsideFile(Student addStudent);

        void DeleteDataInsideFile(Student addStudent);
    }
}
