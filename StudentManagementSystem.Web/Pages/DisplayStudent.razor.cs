using Microsoft.AspNetCore.Components;
using StudentManagementSystem.Library;
using StudentManagementSystem.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.Web.Pages
{
    public class DisplayStudentBase : ComponentBase
    {
        [Parameter]
        public Student Student { get; set; }

        [Inject]
        public IStudentService StudentService { get; set; }

        [Parameter]
        public EventCallback<int> OnStudentDeleted { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

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
                await OnStudentDeleted.InvokeAsync(Student.RollNo);
            }
        }
    }
}
