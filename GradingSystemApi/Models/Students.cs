using System.ComponentModel.DataAnnotations;
namespace Team_Yeri_enrollment_system.GradingLibrary.Models

{
    public class Students
    {
        [Key]
        [Required]
        public required int Student_ID { get; set; }

        [MaxLength(200)]
        public required string Name { get; set; }
        [MaxLength(123)]
        public required DateOnly BirthDate { get; set; }

        [Required]
        [MaxLength(1)]
        public required char Sex { get; set; }
        [Required]
        [MaxLength(60)]
        public required string Gmail { get; set; }
        [Required]
        [MaxLength(20)]
        public required string Number { get; set; }
    }
}