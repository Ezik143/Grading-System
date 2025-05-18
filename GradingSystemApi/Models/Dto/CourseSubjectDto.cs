using GradingSystemApi.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Team_Yeri_enrollment_system.GradingLibrary.Models;

namespace GradingSystemApi.Models.Dto
{
    public class CourseSubjectDto
    {
        public required int CourseID { get; set; }
        public required string SubjectCode { get; set; }
    }
}
