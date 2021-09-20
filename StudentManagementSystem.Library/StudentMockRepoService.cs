using System.Collections.Generic;

namespace StudentManagementSystem.Library
{
    public class StudentMockRepoService : IStudentRepoService
    {
        private List<Student> _listOfStudents;

        public void DeleteStudent(Student removeStudent)
        {
            _listOfStudents?.Remove(removeStudent);
        }

        public List<Student> FetchStudents()
        {
            if (_listOfStudents == null)
            {
                _listOfStudents = GetData();
            }

            return _listOfStudents;
        }

        public void AddStudent(Student addStudent)
        {
            _listOfStudents?.Add(addStudent);
        }


        /// <summary>
        /// hardcoded data in repo
        /// </summary>
        private List<Student> GetData()
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
