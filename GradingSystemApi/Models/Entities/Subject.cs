    using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Team_Yeri_enrollment_system.GradingLibrary.Models;
namespace GradingSystemApi.Models.Entities
{
    // Represents a subject or course component in the academic system
    public class Subject
    {
        // Primary key for the Subject entity, not auto-generated
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public required string SubjectCode { get; set; }

        // Name of the subject (e.g., "Calculus I")
        [Required]
        public required string SubjectName { get; set; }

        // Number of units/credits assigned to the subject
        [Required]
        public required int Units { get; set; }
    }
}