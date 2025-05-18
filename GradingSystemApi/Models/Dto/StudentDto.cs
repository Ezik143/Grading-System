using GradingSystemApi.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Team_Yeri_enrollment_system.GradingLibrary.Models;

namespace GradingSystemApi.Models.Dto
{
    public class StudentDto
    {
        public required string FirstName { get; set; }
        public required string MiddleName { get; set; }
        public required string LastName { get; set; }
        public required DateOnly BirthDate { get; set; }
        public required char Sex { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
    }
}
