using System.ComponentModel.DataAnnotations;
namespace Team_Yeri_enrollment_system.GradingLibrary.Models
{
    public class Subject
    {
        [Key]
        [Required]
        public required string Subject_Code { get; set; }
        [Required]
        public required string Subject_Name { get; set; }
        [Required]
        public required int Units { get; set; }
    }
}