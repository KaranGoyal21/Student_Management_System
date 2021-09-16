using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/studentmanagement")]
    public class StudentManagementController : ControllerBase
    {
        StudentManagementService _services;
        ValidateInputs _validate = new ValidateInputs();
        IStudentRepoService studentRepoService = new StudentFileRepoService();

        public StudentManagementController()
        {
            _services = new StudentManagementService(studentRepoService);
        }

        // GET: api/<StudentManagementController>
        [HttpGet("allstudents")]
        public List<Student> GetStudents()
        {
            return _services.DisplayAllStudentsData();
        }

        [HttpGet("student_name_by_{rollNo}")]
        public string GetStudentName(int rollNo)
        {
            return _services.GetName(rollNo);
        }

        [HttpGet("student_rollNo_by_{name}")]
        public int GetStudentRollNo(string name)
        {
            return _services.GetRollNo(name);
        }

        // GET api/<StudentManagementController>/5
        [HttpGet("student_details")]
        public Student GetStudentDetails(int rollNo)
        {
            return _services.GetDetailsOfSingleStudent(rollNo);
        }

        // POST api/<StudentManagementController>
        [HttpPost("addstudent")]
        public IActionResult AddStudent([FromBody] Student addstudent)
        {
            try
            {
                if (addstudent == null || !ModelState.IsValid)
                {
                    return BadRequest();
                }
                else
                {
                    _services.AddStudent(addstudent);
                    return Ok(addstudent);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        //// PUT api/<StudentManagementController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<StudentManagementController>/5
        [HttpDelete("delete_student{rollNo}")]
        public IActionResult DeleteStudent(int rollNo)
        {
            try
            {
                if (rollNo == default)
                {
                    return BadRequest();
                }
                else
                {
                    _services.RemoveStudent(rollNo);
                    return Ok($"Student with roll no: {rollNo} is deleted");
                }
            }
            catch
            {
                return BadRequest();
            }

        }
    }
}
