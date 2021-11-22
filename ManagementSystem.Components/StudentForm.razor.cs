using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using StudentManagementSystem.Library;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace ManagementSystem.Components
{
    public class StudentFormBase : ComponentBase
    {
        [Parameter]
        public string PageHeaderText { get; set; }

        private Student Student { get; set; } = new Student();

        [Parameter]
        public Student EditStudentModel { get; set;} 

        //[Parameter]
        //public int Standard { get; set; }
        [Parameter]
        public int RollNo { get; set; }

        //[Parameter]
        //[Required(ErrorMessage = "Name must be provided")]
        //[MinLength(2)]
        //public string Name { get; set; }

        //[Parameter]
        //public int Age { get; set; }

        //[Parameter]
        //public double Height { get; set; }

        //[Parameter]
        //public string Address { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public EventCallback HandleValidSubmit { get; set; }

        //protected async override Task OnInitializedAsync()
        //{
        //    Student = EditStudentModel;
        //    Mapper.Map(EditStudentModel, Student);
        //}


        public void Show()
        {
            StateHasChanged();
        }

        [Parameter]
        public EventCallback<bool> InvokeForm { get; set; }


        //protected async Task HandleValidSubmit()
        //{
        //    //Mapper.Map(EditStudentModel, Student);
        //}

        protected async Task OnConfirmationChange(bool value)
        {
            await InvokeForm.InvokeAsync(value);
        }


    }
}

