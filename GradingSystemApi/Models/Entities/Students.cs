using GradingSystemApi.Models.Entities;
using System.ComponentModel.DataAnnotations;
namespace GradingSystemApi.Models.Entities

{
    public class Students
    {
        [Key]
        [Required]
        public required int studentID { get; set; }

        [MaxLength(200)]
        public required string Name { get; set; }
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
        //Student relation to Grades is Zero to many
        public ICollection<Grades> Grades { get; set; } = new List<Grades>(); //explanation is at the end of the file
        //Student relation to Enrollments is Zero to many
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>(); //explanation is at the end of the file
    }
}
//ICollection<T> is a reference type.
//If you don’t give it a value, it's null.
//Accessing or calling methods on a null reference throws a NullReferenceException
/// <summary>
/// public ICollection<Grades> Grades { get; set; } // <-- null by default
/// if you do this:
/// var student = new Student();
/// student.Grades.Add(new Grades()); // 💥 CRASH! Grades is null!
/// It crashes because you're saying “Hey Grades, add this new grade,” but Grades doesn’t even exist yet.
/// </summary>