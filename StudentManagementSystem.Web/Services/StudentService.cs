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
        public async Task<Student> AddStudent(Student addStudent)
        {
            var httpResponseMessage = await httpClient.PostAsJsonAsync<Student>("api/studentmanagement/addstudent", addStudent);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return await httpResponseMessage.Content.ReadFromJsonAsync<Student>();
            }
            return null;
        }

        public async Task DeleteStudent(int rollNo, Student removeStudent)
        {
           await httpClient.DeleteAsync($"api/studentmanagement/delete_student{rollNo}");
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

        public async Task<Student> UpdateStudent(Student updatedstudent)
        {
            var httpResponseMessage = await httpClient.PutAsJsonAsync<Student>("api/studentmanagement/add subject {rollNo}", updatedstudent);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return await httpResponseMessage.Content.ReadFromJsonAsync<Student>();
            }
            return null;
        }
    }
}
