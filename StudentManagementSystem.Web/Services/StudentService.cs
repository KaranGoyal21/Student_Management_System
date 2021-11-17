using StudentManagementSystem.Library;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace StudentManagementSystem.Web.Services
{
    public class StudentService : IStudentService
    {
        private readonly HttpClient httpClient = new HttpClient();

        public StudentService(HttpClient httpClient)
        {
            //httpClient.BaseAddress = new Uri("http://localhost:2784");
            this.httpClient = httpClient;
        }
        public void AddStudent(Library.Student addStudent)
        {
            throw new NotImplementedException();
        }

        public void DeleteStudent(int rollNo, Library.Student removeStudent)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Student>> FetchStudents()
        {
            return await httpClient.GetFromJsonAsync<List<Student>>("api/studentmanagement/allstudents");
        }

        public async Task<Student> GetStudentDetails(int rollNo)
        {
            return await httpClient.GetFromJsonAsync<Student>($"api/studentmanagement/student_details/{rollNo}");
        }

        public async Task<Student> GetStudentName(int rollNo)
        {
            return await httpClient.GetFromJsonAsync<Student>($"api/studentmanagement/student_name_by_{rollNo}");
        }

        public async Task<Student> GetStudentRollNo(string name)
        {
            return await httpClient.GetFromJsonAsync<Student>($"api/studentmanagement/student_rollNo_by_{name}");
        }

        public void UpdateStudent(int rollNo, Library.Student student)
        {
            throw new NotImplementedException();
        }
    }
}
