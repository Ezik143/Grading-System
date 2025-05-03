using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Team_Yeri_enrollment_system.GradingLibrary.Models
{
    public class Enrollment
    {
        [Key]
        [Required]
        public required int Enrollment_ID { get; set; }
        [Required]
        public required int Student_ID { get; set; }
        [Required]
        public required int Course_ID { get; set; }
        [Required]
        public required int Term_ID { get; set; }
        [Required]
        public required char Enrollment_status { get; set; }

    }
}