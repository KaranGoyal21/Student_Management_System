using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using StudentManagementSystem.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Web.Pages
{
    public class EditStudentModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int Standard { get; set; }
        public int RollNo { get; set; }

        [Required(ErrorMessage = "Name must be provided")]
        [MinLength(2)]
        public string Name { get; set; }

        public int Age { get; set; }

        public double Height { get; set; }
        public string Address { get; set; }

        public List<SubjectSelectionRepository> Subjects { get; set; }

        public bool AddingSubject(SubjectSelectionRepository subject)
        {
            bool subjectExists = false;
            foreach (var eachSubject in Subjects)
            {
                if (subject == eachSubject)
                {
                    subjectExists = true;
                    break;
                }
            }

            if (subjectExists)
            {
                Console.WriteLine($"Cannot Add {subject} Subject as it already exists");
                return false;
            }
            else
            {
                this.Subjects.Add(subject);
                Console.WriteLine($"Added {subject} Subject Successfully");
                return true;
            }
        }

        public bool RemovingSubject(SubjectSelectionRepository subject)
        {
            var subjectExists = false;
            foreach (var eachSubject in Subjects)
            {
                if(eachSubject == subject)
                {
                    subjectExists = true;
                    break;
                }
            }

            if(subjectExists)
            {
                this.Subjects.Remove(subject);
                Console.WriteLine($"{subject} Subject Deleted");
                return true;
            }
            else
            {
                Console.WriteLine($"{subject} Subject Not Found");
                return false;
            }
        }

        public bool AddingSubject(List<SubjectSelectionRepository> subjects)
        {
            foreach(var sub in subjects)
            {
                AddingSubject(sub);
            }
            return true;//future implementation of this logic
        }

        public bool RemovingSubject(List<SubjectSelectionRepository> subjects)
        {
            foreach(var sub in subjects)
            {
                RemovingSubject(sub);
            }
            return true;//future implementation of this logic
        }
    }
}
