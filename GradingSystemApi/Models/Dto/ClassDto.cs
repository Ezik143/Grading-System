using GradingSystemApi.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GradingSystemApi.Models.addDto
{
    public class ClassDto
    {
        public required int TeacherID { get; set; }
        public required string Schedule { get; set; }
    }
}