namespace App.Models
{
    public class AddCourseModel
    {
        public required string Code { get; set; }
        public required string Name { get; set; }
        public required int Duration { get; set; }
        public required decimal Fee { get; set; }
    }
}
