using Microsoft.AspNetCore.Components;
using StudentManagementSystem.Library;
using StudentManagementSystem.Web.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.Web.Pages
{
    public class StudentListBase : ComponentBase
    {
        //StudentService x = new StudentService();

        [Inject]
        public IStudentService StudentService { get; set; }

        public IEnumerable<Student> Students { get; set; }

        //protected async override Task OnAfterRenderAsync(bool firstRender)
        //{
        //    if (firstRender)
        //    {
        //        Students = await x.FetchStudents();
        //        StateHasChanged();
        //    }
        //}

        protected async override Task OnInitializedAsync()
        {
            Students = (await StudentService.FetchStudents()).ToList();
        }

        //protected async override void OnInitializedAsync()
        //{
        //    Students = await x.FetchStudents();
        //}
    }
}
