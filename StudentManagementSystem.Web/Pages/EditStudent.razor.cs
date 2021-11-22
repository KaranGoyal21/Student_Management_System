using AutoMapper;
using Microsoft.AspNetCore.Components;
using StudentManagementSystem.Library;
using StudentManagementSystem.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.Web.Pages
{
    public class EditStudentBase : ComponentBase
    {
        [Inject]
        public IStudentService StudentService { get; set; }

        public string PageHeaderText { get; set; }

        private Student Student { get; set; } = new Student();

        public EditStudentModel EditStudentModel { get; set; } = new EditStudentModel();

        [Parameter]
        public string RollNo { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected async override Task OnInitializedAsync()
        {
            int.TryParse(RollNo, out int studentRollNo);

            if (studentRollNo != 0)
            {
                PageHeaderText = "Edit Student";
                Student = await StudentService.GetStudentDetails(int.Parse(RollNo));
            }
            else
            {
                PageHeaderText = "Create Student";
                Student = new Student
                {
                    Standard = 1
                };
            }
            Mapper.Map(Student, EditStudentModel);

        }

        protected async Task HandleValidSubmit()
        {
            Mapper.Map(EditStudentModel, Student);

            Student result = null;

            int.TryParse(RollNo, out int studentRollNo);

            if (Student.RollNo == studentRollNo)
            {
                result = await StudentService.UpdateStudent(Student);
            }
            else
            {
                result = await StudentService.AddStudent(Student);
            }

            if (result != null)
            {
                NavigationManager.NavigateTo("/");
            }
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

