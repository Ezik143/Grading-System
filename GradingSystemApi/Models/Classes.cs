using System.ComponentModel.DataAnnotations;
namespace Team_Yeri_enrollment_system.GradingLibrary.Models
{
    public class Classes
    {
        [Key]
        public required int Class_ID { get; set; }
        public required int Teacher_ID { get; set; }
        public required string Schedule { get; set; }
        public required string Subject_Code { get; set; }

    }
}