using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentManagementSystem.API.Controllers
{
    [Route("api/student-management")]
    [ApiController]
    public class StudentManagementController : ControllerBase
    {
        StudentManagementService _services;
        ValidateInputs _validate = new ValidateInputs();
        IStudentRepoService studentRepoService = new MockStudentRepoService();

        public StudentManagementController()
        {
            _services = new StudentManagementService(studentRepoService);
        }

        // GET: api/<StudentManagementController>
        [HttpGet("display-all")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<StudentManagementController>/5
        [HttpGet("{id}")]
        public Student Get(int id)
        {
            return _services.GetDetailsOfSingleStudent(id);
        }

        // POST api/<StudentManagementController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StudentManagementController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StudentManagementController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
