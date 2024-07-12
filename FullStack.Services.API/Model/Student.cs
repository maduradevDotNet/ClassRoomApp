using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FullStack.Services.API.Model
{
    public class Student
    {
        [Key] // Specifies that this property is the primary key
        public int StudentId { get; set; }

        [Required] // Makes this property mandatory
        [StringLength(50)] // Sets the maximum length of the string
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Range(1, 120)] // Sets the valid range for age
        public int Age { get; set; }

        [DataType(DataType.Date)] // Specifies that this property is a date
        public DateTime EnrollmentDate { get; set; }

        [NotMapped] // Specifies that this property is not mapped to a database column
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }
}
