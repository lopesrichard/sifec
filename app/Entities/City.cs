namespace App.Entities
{
    public class City : Entity
    {
        public required string Code { get; set; }
        public required string Name { get; set; }
        public required string State { get; set; }
    }
}