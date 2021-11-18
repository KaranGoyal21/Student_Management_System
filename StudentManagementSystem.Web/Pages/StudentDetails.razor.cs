using Microsoft.AspNetCore.Components;
using StudentManagementSystem.Library;
using StudentManagementSystem.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.Web.Pages
{
    public class StudentDetailsBase : ComponentBase
    {
        public Student Student { get; set; } = new Student();

        [Inject]
        public IStudentService StudentService { get; set; }

        [Parameter]
        public string RollNo { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected async override Task OnInitializedAsync()
        {
            RollNo = RollNo ?? "101";
            Student = await StudentService.GetStudentDetails(int.Parse(RollNo));
        }
        protected ManagementSystem.Components.ConfirmBase DeleteConfirmation { get; set; }

        protected void Delete_Click()
        {
            DeleteConfirmation.Show();
        }

        protected async Task ConfirmDelete_Click(bool deleteConfirmed)
        {
            if (deleteConfirmed)
            {
                await StudentService.DeleteStudent(Student.RollNo, Student);
                NavigationManager.NavigateTo("/");
            }
        }
    }
}
