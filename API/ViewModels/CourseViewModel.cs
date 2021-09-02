using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace API.ViewModels
{
    public class CourseViewModel
    {
        public string CourseTitle { get; set; }
        public int CourseNumber { get; set; }
        public bool IsRetired { get; set; }
    }
}