using System.ComponentModel.DataAnnotations;
namespace Team_Yeri_enrollment_system.GradingLibrary.Models
{
    public class Terms
    {
        [Key]
        [Required]
        public required int Term_ID { get; set; }
        [Required]
        public required string Term_Name { get; set; }
        [Required]

        public required DateOnly Academic_Year { get; set; }
    }
}