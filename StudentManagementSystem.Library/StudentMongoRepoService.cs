using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IO;

namespace StudentManagementSystem.Library
{
    public class StudentMongoRepoService : IStudentRepoService
    {
        private List<Student> _listOfStudents;
        const string _databaseName = "StudentsData";
        const string _table = "Students";
        private readonly IMongoDatabase _db;

        public StudentMongoRepoService()
        {
            var client = new MongoClient();
            _db = client.GetDatabase(_databaseName);
        }

        public void AddStudent(Student addStudent)
        {
            var collection = _db.GetCollection<Student>(_table);
            collection.InsertOne(addStudent);
        }

        public void DeleteStudent(int rollNo, Student removeStudent)
        {
            var collection = _db.GetCollection<Student>(_table);
            var filter = Builders<Student>.Filter.Eq("RollNo", removeStudent.RollNo);
            collection.DeleteOne(filter);

        }

        public List<Student> FetchStudents()
        {
            var collection = _db.GetCollection<Student>(_table);
            _listOfStudents= collection.Find(new BsonDocument()).ToList();
            return _listOfStudents;
        }

        public void UpdateStudent(int rollNo, Student student)
        {
            var collection = _db.GetCollection<Student>(_table);
            var result = collection.ReplaceOne(
                new BsonDocument("RollNo", rollNo),
                student,
                new ReplaceOptions { IsUpsert = true });
        }

    }
}
