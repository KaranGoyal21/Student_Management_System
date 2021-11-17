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

    }
}
