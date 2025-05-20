using System.ComponentModel.DataAnnotations;
namespace GradingSystemApi.Models.Entities
{
    // Represents an academic term or period (e.g., "1st Semester", "2024-2025")
    public class Term
    {
        // Primary key for the Term entity
        [Key]
        [Required]
        public int TermID { get; set; }

        // Name of the term (e.g., "First Semester", "Second Trimester")
        [Required]
        public required string TermName { get; set; }

        // Academic year associated with the term
        [Required]
        public required DateOnly AcademicYear { get; set; }
    }
}