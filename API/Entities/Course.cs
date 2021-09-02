using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Course", Schema = "Courses")]
    public class Course
    {
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        public string CourseTitle { get; set; }

        public int CourseNumber { get; set; }

        public bool IsRetired { get; set; }
    }
}