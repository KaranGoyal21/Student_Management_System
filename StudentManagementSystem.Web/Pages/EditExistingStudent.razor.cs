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
    public class EditExistingStudentBase : ComponentBase
    {
        [Inject]
        public IStudentService StudentService { get; set; }

        public Student StudentData { get; set; } = new Student();

        protected EditStudentModel EditStudentModel { get; set; } = new EditStudentModel();

        [Parameter]
        public string RollNo { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected async override Task OnInitializedAsync()
        {
            StudentData = await StudentService.GetStudentDetails(int.Parse(RollNo));
            Mapper.Map(StudentData, EditStudentModel);
        }

        protected async Task HandleValidSubmit()
        {
            Mapper.Map(StudentData, EditStudentModel);

            Student result = null;

            int.TryParse(RollNo, out int studentRollNo);

            if (StudentData.RollNo == studentRollNo)
            {
                result = await StudentService.UpdateStudent(StudentData);
            }

            if (result != null)
            {
                NavigationManager.NavigateTo("/", true);
            }
        }

        public ManagementSystem.Components.StudentForm EditStudentForm { get; set; }

        protected void OpenCreateForm()
        {
            EditStudentForm.Show();
        }

    }
}
