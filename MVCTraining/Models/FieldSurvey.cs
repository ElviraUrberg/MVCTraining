using System.ComponentModel.DataAnnotations;

namespace MVCTraining.Models
{
    public class FieldSurvey
    {
        public int Id { get; set; }

        [Required]
        public string Service { get; set; }

        [Required]
        public string Area { get; set; }

        [Required]
        public string Category { get; set; }
        public string? Status { get; set; }
        public string? Photopath { get; set; }
        public string? Comment { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
