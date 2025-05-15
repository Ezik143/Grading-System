using GradingSystemApi.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Team_Yeri_enrollment_system.GradingLibrary.Models;

namespace GradingSystemApi.Models.Dto
{
    public class EnrollmentDto
    {
        [Required]
        public  required int StudentID { get; set; }
        [Required]
        public  required int CourseID { get; set; }
        [Required]
        public  required int TermID { get; set; }
        [Required]
        public  required string EnrollmentStatus { get; set; }
    }
}
