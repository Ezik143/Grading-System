using GradingSystemApi.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Team_Yeri_enrollment_system.GradingLibrary.Models;

namespace GradingSystemApi.Models.Dto
{
    public class EnrollmentDto
    {
        [Required]
        public  int StudentID { get; set; }
        public  int CourseID { get; set; }
        public  int TermID { get; set; }
        public  char EnrollmentStatus { get; set; }
    }
}
