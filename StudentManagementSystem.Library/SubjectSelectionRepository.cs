using System.Text.Json.Serialization;

namespace StudentManagementSystem.Library
{
    [JsonConverter(typeof(JsonStringEnumConverter))]

    public enum SubjectSelectionRepository
    {
        History = 1,
        Geography,
        Maths,
        English,
        German,
        Marathi,
        Hindi,
        Science
    }
}
