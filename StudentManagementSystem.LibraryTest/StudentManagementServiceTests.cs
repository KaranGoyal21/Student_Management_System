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
            var listOfStudents = GetStudentData();
            StudentManagementService studentManagementService = new StudentManagementService(listOfStudents);
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
            var listOfStudents = GetStudentData();
            StudentManagementService studentManagementService = new StudentManagementService(listOfStudents);
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
            var listOfStudents = GetStudentData();
            StudentManagementService studentManagementService = new StudentManagementService(listOfStudents);
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
            var listOfStudents = GetStudentData();
            StudentManagementService studentManagementService = new StudentManagementService(listOfStudents);
            List<SubjectSelectionRepository> subjectsOfStudent = new List<SubjectSelectionRepository>() { SubjectSelectionRepository.German, SubjectSelectionRepository.Hindi, SubjectSelectionRepository.History, SubjectSelectionRepository.Marathi };
            Student student1 = new Student(8, 102, "FakeName", 13, 5.5, "Chinchwad", subjectsOfStudent);

            //--Act

            int resultRollNo = studentManagementService.GetRollNo(student1.Name);

            //--Assert
            Assert.AreEqual(default(int), resultRollNo);
        }


        private List<Student> GetStudentData()
        {
            List<SubjectSelectionRepository> subjectsOfStudent1 = new List<SubjectSelectionRepository>() { SubjectSelectionRepository.English, SubjectSelectionRepository.Geography, SubjectSelectionRepository.German };
            Student student1 = new Student(10, 101, "Alex", 15, 5.8, "Pimple Gurav", subjectsOfStudent1);

            List<SubjectSelectionRepository> subjectsOfStudent2 = new List<SubjectSelectionRepository>() { SubjectSelectionRepository.German, SubjectSelectionRepository.Hindi, SubjectSelectionRepository.History, SubjectSelectionRepository.Marathi };
            Student student2 = new Student(8, 102, "Stacy", 13, 5.5, "Chinchwad", subjectsOfStudent2);


            List<SubjectSelectionRepository> subjectsOfStudent3 = new List<SubjectSelectionRepository>() { SubjectSelectionRepository.History };
            Student student3 = new Student(9, 103, "Max", 14, 5.6, "Koregoan Park", subjectsOfStudent3);

            List<SubjectSelectionRepository> subjectsOfStudent4 = new List<SubjectSelectionRepository>() { SubjectSelectionRepository.Maths, SubjectSelectionRepository.Science };
            Student student4 = new Student(7, 104, "Owen", 12, 5.4, "Shivajinagar", subjectsOfStudent4);

            List<SubjectSelectionRepository> subjectsOfStudent5 = new List<SubjectSelectionRepository>() { SubjectSelectionRepository.English, SubjectSelectionRepository.Science };
            Student student5 = new Student(6, 105, "Justin", 11, 5.2, "Kothrud", subjectsOfStudent5);


            return new List<Student>() { student1, student2, student3, student4, student5 };
        }
    }
}
