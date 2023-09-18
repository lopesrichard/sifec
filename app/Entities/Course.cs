using App.Exceptions;

namespace App.Entities
{
    public class Course : Entity
    {
        public required string Code { get; set; }
        public required string Name { get; set; }
        public required int Duration { get; set; }
        public required decimal Fee { get; set; }

        public Institution Institution
        {
            set => _institution = value;
            get => _institution ?? throw new UninitializedPropertyException(nameof(Institution));
        }

        private Institution? _institution;
    }
}