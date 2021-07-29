using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentManagementSystem.Library;
using System.Collections.Generic;

namespace StudentManagementSystem.LibraryTest
{
    [TestClass]
    public class StudentManagementServiceTests
    {

        [TestMethod]
        public void GetStudentName_WithValidRollNo_ReturnsStudentName()
        {
            //--Arrange
            StudentManagementService studentManagementService = new StudentManagementService();

            List<SubjectSelectionRepository> subjectsOfStudent = new List<SubjectSelectionRepository>() { SubjectSelectionRepository.German, SubjectSelectionRepository.Hindi, SubjectSelectionRepository.History, SubjectSelectionRepository.Marathi };
            Student student = new Student(8, 102, "Stacy", 13, 5.5, "Chinchwad", subjectsOfStudent);

            //--Act

            string resultName = studentManagementService.GetName(student.RollNo);

            //--Assert
            Assert.AreEqual(student.Name, resultName);
        }

        public void GetStudentName_WithInValidRollNo_ReturnsNull()
        {
            //--Arrange
            StudentManagementService studentManagementService = new StudentManagementService();

            List<SubjectSelectionRepository> subjectsOfStudent = new List<SubjectSelectionRepository>() { SubjectSelectionRepository.German, SubjectSelectionRepository.Hindi, SubjectSelectionRepository.History, SubjectSelectionRepository.Marathi };
            Student student = new Student(8, 609, "FakeStudent", 13, 5.5, "Chinchwad", subjectsOfStudent);

            //--Act

            string resultName = studentManagementService.GetName(student.RollNo);

            //--Assert
            Assert.AreEqual(default(string), resultName);
        }
    }
}
