namespace App.Models
{
    public class AddSimulationModel
    {
        public required Guid Institution { get; set; }
        public required Guid Course { get; set; }
        public required int Semester { get; set; }
        public required decimal Fee { get; set; }
        public required string Name { get; set; }
        public required string Document { get; set; }
        public required string Email { get; set; }
        public required Guid City { get; set; }
    }
}
