using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using GradingSystemApi.Models.Entities;

namespace GradingSystemApi.Models.Dto
{
    public class GradeDto
    {
        public required string EducationLevel { get; set; }
        public int ClassID { get; set; }
        public decimal GradeValue { get; set; }
        public decimal GradeEquivalent { get; set; }
        public required string Remark { get; set; }
        public int GradingPeriodID { get; set; }
        public int EnrollmentID { get; set; }
        public DateOnly DateRecorded { get; set; }
    }
}
