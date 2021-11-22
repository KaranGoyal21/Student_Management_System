using AutoMapper;
using ManagementSystem.Components;
using Microsoft.AspNetCore.Components;
using StudentManagementSystem.Library;
using StudentManagementSystem.Web.Services;
using System.Threading.Tasks;

namespace StudentManagementSystem.Web.Pages
{
    public class CreateStudentBase : ComponentBase
    {
        [Inject]
        public IStudentService StudentService { get; set; }

        [Inject]
        public StudentForm StudentForm { get; set; }

        public Student StudentData { get; set; } = new Student();

        //public EditStudentModel EditStudentModel { get; set; } = new EditStudentModel();

        //[Parameter]
        //public string RollNo { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected async override Task OnInitializedAsync()
        {
            StudentData = new Student { Standard = 1 , Name = "John Doe"};

            //StudentForm.EditStudentModel=StudentData;

            //Mapper.Map(StudentData, StudentForm.EditStudentModel);
        }

        protected async Task HandleValidSubmit()
        {
            Mapper.Map(StudentForm.EditStudentModel, StudentData);

            Student result = await StudentService.AddStudent(StudentData);
            NavigationManager.NavigateTo("/");
        }

        //public ManagementSystem.Components.StudentForm CreateStudentForm { get; set; }

        //public StudentManagementSystem.Web.Pages.StudentFormBase CreateStudentForm { get; set; }


        protected void OpenCreateForm()
        {
            StudentForm.Show();
        }

    }
}
