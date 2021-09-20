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

        public void DeleteStudent(Student removeStudent)
        {
            var collection = _db.GetCollection<Student>(_table);
            var filter = Builders<Student>.Filter.Eq("Id", removeStudent.Id);
            collection.DeleteOne(filter);

        }

        public List<Student> FetchStudents()
        {
            var collection = _db.GetCollection<Student>(_table);
            _listOfStudents= collection.Find(new BsonDocument()).ToList();
            return _listOfStudents;
        }
    }
}
