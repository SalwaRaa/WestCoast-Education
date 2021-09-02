using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace API.ViewModels
{
    public class AddCourseViewModel 
    {
        public string CourseTitle { get; set; }
        public int CourseNumber { get; set; }
    }
}
