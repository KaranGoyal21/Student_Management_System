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

        public Student StudentData { get; set; } = new Student();

        [Inject]
        public IMapper Mapper { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected async override Task OnInitializedAsync()
        {
            StudentData = new Student { Standard = 1 , Name = "John Doe"};
        }

        protected async Task HandleValidSubmit()
        {
            Student result = await StudentService.AddStudent(StudentData);
            NavigationManager.NavigateTo("/");
        }

        public ManagementSystem.Components.StudentForm CreateStudentForm { get; set; }

        protected void OpenCreateForm()
        {
            CreateStudentForm.Show();
        }

    }
}
