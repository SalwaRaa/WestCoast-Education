using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using API.ViewModels;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace API.Data
{
    public class CourseRepository : ICourseRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public CourseRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CourseViewModel>> GetCoursesAsync()
        {
            var result = await _context.Courses.ToListAsync();
            var mapped = _mapper.Map<IEnumerable<CourseViewModel>>(result);
            return mapped;
        }

        public async Task<Course> GetCourseByIdAsync(int id)
        {
            return await _context.Courses.FindAsync(id);
        }

        public async Task<CourseViewModel> GetCourseByTitleAsync(string courseTitle)
        {
            return await _context.Courses
            .ProjectTo<CourseViewModel>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(c => c.CourseTitle == courseTitle);
        }

        public async Task<IEnumerable<CourseViewModel>> GetCourseByPartialTitleAsync(string coursePartialTitle)
        {
            var trimmedTitle = coursePartialTitle.Trim();
            var listOfTitleMatches = await _context.Courses.Where(course => course.CourseTitle.Contains(trimmedTitle)).ToListAsync();
            var results = _mapper.Map<IEnumerable<CourseViewModel>>(listOfTitleMatches);
            return results;
        }

        public async Task<CourseViewModel> GetCourseByNumberAsync(int courseNumber)
        {
            return await _context.Courses
            .ProjectTo<CourseViewModel>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(c => c.CourseNumber == courseNumber);
        }

        public void Add(AddCourseViewModel course)
        {
            var courseToAdd = _mapper.Map<Course>(course, opt =>
            {
                opt.Items["repo"] = _context;
            });
            _context.Entry(courseToAdd).State = EntityState.Added;
        }

        public void Update(Course course, int id)
        {
            _context.Entry(course).State = EntityState.Modified;
        }
    }
}