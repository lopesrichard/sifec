using System.Text.Json.Serialization;

namespace App.Entities
{
    public class Institution : Entity
    {
        public required string Code { get; set; }
        public required string Name { get; set; }

        [JsonIgnore]
        public ICollection<Course> Courses { get; set; }

        public Institution()
        {
            Courses = new HashSet<Course>();
        }
    }
}