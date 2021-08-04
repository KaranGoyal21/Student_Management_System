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
            IStudentRepoService studentRepoService = new TestMockStudentRepoService();
            StudentManagementService studentManagementService = new StudentManagementService(studentRepoService);
            List<SubjectSelectionRepository> subjectsOfStudent = new List<SubjectSelectionRepository>() { SubjectSelectionRepository.German, SubjectSelectionRepository.Hindi, SubjectSelectionRepository.History, SubjectSelectionRepository.Marathi };
            Student student = new Student(8, 102, "Stacy", 13, 5.5, "Chinchwad", subjectsOfStudent);


            //--Act

            string resultName = studentManagementService.GetName(student.RollNo);

            //--Assert
            Assert.AreEqual(student.Name, resultName);
        }

        [TestMethod]
        public void GetStudentName_WithInValidRollNo_ReturnsNull()
        {
            //--Arrange
            IStudentRepoService studentRepoService = new TestMockStudentRepoService();
            StudentManagementService studentManagementService = new StudentManagementService(studentRepoService);
            List<SubjectSelectionRepository> subjectsOfStudent = new List<SubjectSelectionRepository>() { SubjectSelectionRepository.German, SubjectSelectionRepository.Hindi, SubjectSelectionRepository.History, SubjectSelectionRepository.Marathi };
            Student student = new Student(8, 609, "FakeStudent", 13, 5.5, "Chinchwad", subjectsOfStudent);

            //--Act

            string resultName = studentManagementService.GetName(student.RollNo);

            //--Assert
            Assert.AreEqual(default(string), resultName);
        }

        [TestMethod]
        public void GetStudentRollNo_WithValidName_ReturnsStudentRollNo()
        {
            //--Arrange
            IStudentRepoService studentRepoService = new TestMockStudentRepoService();
            StudentManagementService studentManagementService = new StudentManagementService(studentRepoService);
            List<SubjectSelectionRepository> subjectsOfStudent = new List<SubjectSelectionRepository>() { SubjectSelectionRepository.German, SubjectSelectionRepository.Hindi, SubjectSelectionRepository.History, SubjectSelectionRepository.Marathi };
            Student student1 = new Student(8, 102, "Stacy", 13, 5.5, "Chinchwad", subjectsOfStudent);

            //--Act

            int resultRollNo = studentManagementService.GetRollNo(student1.Name);

            //--Assert
            Assert.AreEqual(student1.RollNo, resultRollNo);
        }

        [TestMethod]
        public void GetStudentRollNo_WithInValidName_ReturnsZero()
        {
            //--Arrange
            IStudentRepoService studentRepoService = new TestMockStudentRepoService();
            StudentManagementService studentManagementService = new StudentManagementService(studentRepoService);
            List<SubjectSelectionRepository> subjectsOfStudent = new List<SubjectSelectionRepository>() { SubjectSelectionRepository.German, SubjectSelectionRepository.Hindi, SubjectSelectionRepository.History, SubjectSelectionRepository.Marathi };
            Student student1 = new Student(8, 102, "FakeName", 13, 5.5, "Chinchwad", subjectsOfStudent);

            //--Act

            int resultRollNo = studentManagementService.GetRollNo(student1.Name);

            //--Assert
            Assert.AreEqual(default(int), resultRollNo);
        }
    }
}
