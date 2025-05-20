using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GradingSystemApi.Models.Entities
{
    // Represents a grading period within an academic term (e.g., "First Quarter", "Midterm")
    public class GradingPeriod
    {
        // Primary key for the GradingPeriod entity
        [Key]
        public int GradingPeriodID { get; set; }

        // Foreign key referencing the Term entity
        public int TermID { get; set; }

        // Navigation property for the related Term (e.g., semester or school year)
        [ForeignKey("TermID")]
        public Term? Term { get; set; }

        // Name of the grading period (e.g., "First Quarter", "Finals")
        [Required]
        public required string Name { get; set; }
    }
}
