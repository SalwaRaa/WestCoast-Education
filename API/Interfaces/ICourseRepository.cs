using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using API.ViewModels;

namespace API.Interfaces
{
    public interface ICourseRepository
    {
        Task<IEnumerable<CourseViewModel>> GetCoursesAsync();
        Task<Course> GetCourseByIdAsync(int id);
        Task<CourseViewModel> GetCourseByTitleAsync(string courseTitle);
        Task<IEnumerable<CourseViewModel>> GetCourseByPartialTitleAsync(string coursePartialTitle);
        Task<CourseViewModel> GetCourseByNumberAsync(int courseNumber);

        void Add(AddCourseViewModel course);
        void Update(Course course, int id);
    }
}