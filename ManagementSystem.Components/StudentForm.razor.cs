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
        public Student EditStudentModel { get; set; }

        [Parameter]
        public int RollNo { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public EventCallback HandleValidSubmit { get; set; }

        public void Show()
        {
            StateHasChanged();
        }

        [Parameter]
        public EventCallback<bool> InvokeForm { get; set; }

        protected async Task OnConfirmationChange(bool value)
        {
            await InvokeForm.InvokeAsync(value);
        }


    }
}

