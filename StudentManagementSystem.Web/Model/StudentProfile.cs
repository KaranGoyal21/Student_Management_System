using AutoMapper;
using StudentManagementSystem.Library;
using StudentManagementSystem.Web.Pages;

namespace StudentManagementSystem.Web.Model
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, EditStudentModel>();
            CreateMap<EditStudentModel, Student>();
        }
    }
}
