using System.ComponentModel.DataAnnotations;
namespace Team_Yeri_enrollment_system.GradingLibrary.Models
{
    public class Teacher
    {
        [Key]
        [Required]
        public required string Teacher_ID { get; set; }
        [Required]
        public required string First_Name { get; set; }
        [Required]
        public required string Last_name { get; set; }
        [Required]
        public required string Gmail { get; set; }
        [Required]
        public required string Phone_Number { get; set; }
        [Required]
        public required string Department { get; set; }
    }
}