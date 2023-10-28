using System.Text.Json.Serialization;
using App.Exceptions;

namespace App.Entities
{
    public class Simulation : Entity
    {
        public required int Semester { get; set; }
        public required decimal TuitionFee { get; set; }
        public required string Name { get; set; }
        public required string Document { get; set; }
        public required string Email { get; set; }
        public required decimal RequestedAmount { get; set; }
        public required decimal Fee { get; set; }
        public required decimal TotalValue { get; set; }
        public required decimal InstallmentValue { get; set; }
        public required int GracePeriodDays { get; set; }
        public required DateTime FirstPaymentDue { get; set; }
        public required DateTime LastPaymentDue { get; set; }
        public required string ValidationKey { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required bool WasConverted { get; set; }
        public required Guid InstitutionId { get; set; }
        public required Guid CourseId { get; set; }
        public required Guid CityId { get; set; }

        [JsonIgnore]
        public Institution Institution
        {
            set => _institution = value;
            get => _institution ?? throw new UninitializedPropertyException(nameof(Institution));
        }

        private Institution? _institution;

        [JsonIgnore]
        public Course Course
        {
            set => _course = value;
            get => _course ?? throw new UninitializedPropertyException(nameof(Course));
        }

        private Course? _course;

        [JsonIgnore]
        public City City
        {
            set => _city = value;
            get => _city ?? throw new UninitializedPropertyException(nameof(City));
        }

        private City? _city;
    }
}