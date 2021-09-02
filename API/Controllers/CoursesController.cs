using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using API.Interfaces;
using API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace API.Controllers
{
    [ApiController]
    [Route("api/courses")]
    public class CoursesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public CoursesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseViewModel>>> GetCourses()
        {
            var result = await _unitOfWork.CourseRepository.GetCoursesAsync();
            if (result == null) return StatusCode(500, "Something went wrong");
            return Ok(result);
        }
        [HttpGet("searchid/{id}")]
        public async Task<ActionResult<Course>> GetCourseById(int id)
        {
            var result = await _unitOfWork.CourseRepository.GetCourseByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpGet("search/{courseTitle}")]
        public async Task<ActionResult<CourseViewModel>> GetCourseByTitle(string courseTitle)
        {
            var result = await _unitOfWork.CourseRepository.GetCourseByTitleAsync(courseTitle);
            if (result == null) return NotFound($"Unfortunately we were not able to find a course with the course name: {courseTitle}");

            return Ok(result);
        }

        [HttpGet("searchfilter/{coursePartialTitle}")]
        public async Task<ActionResult<IEnumerable<CourseViewModel>>> GetCourseByPartialTitle(string coursePartialTitle)
        {
            var courses = await _unitOfWork.CourseRepository.GetCourseByPartialTitleAsync(coursePartialTitle);
            var isCourseListEmptyOrNull = courses == null || !courses.Any();
            if (isCourseListEmptyOrNull)
            {
                return NotFound();
            }
            return Ok(courses);
        }


        [HttpGet("find/{courseNumber}")]
        public async Task<ActionResult<CourseViewModel>> GetCourseByNumber(int courseNumber)
        {
            var result = await _unitOfWork.CourseRepository.GetCourseByNumberAsync(courseNumber);
            if (result == null) return NotFound($"Unfortunately we were not able to find a course with the course number: {courseNumber}");

            return Ok(result);
        }

        [HttpPost()]
        public async Task<ActionResult> AddCourse(AddCourseViewModel course)
        {
            try
            {
                var result = await _unitOfWork.CourseRepository.GetCourseByTitleAsync(course.CourseTitle);
                if (result != null) return BadRequest("The course already exists in the system");

                _unitOfWork.CourseRepository.Add(course);
                if (await _unitOfWork.Complete()) return StatusCode(201, course.CourseTitle);

                return StatusCode(500, "We were unable to save the course");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPatch("{id}")]

        public async Task<ActionResult> UpdateCourse(int id, UpdateCourseViewModel model)
        {
            try
            {
                var course = await _unitOfWork.CourseRepository.GetCourseByIdAsync(id);

                if (course.IsRetired == true) return BadRequest("The course is already retired");

                course.IsRetired = model.IsRetired;

                _unitOfWork.CourseRepository.Update(course, id);

                if (await _unitOfWork.Complete()) return NoContent();

                return StatusCode(500, "We were unable to save the changes");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}