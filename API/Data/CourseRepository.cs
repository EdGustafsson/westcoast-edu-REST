using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using API.ViewModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

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

        public void Add(CourseViewModel course)
        {
            var newCourse = _mapper.Map<Course>(course);
            _context.Entry(newCourse).State = EntityState.Added;
        }

        public void Delete(Course course)
        {
            _context.Entry(course).State = EntityState.Deleted;
        }

        public async Task<Course> GetCourseByCourseNumberAsync(int coursenumber)
        {
            return await _context.Courses.SingleOrDefaultAsync(c => c.CourseNumber == coursenumber);
        }

        public async Task<Course> GetCourseByIdAsync(int id)
        {
            return await _context.Courses.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Course>> GetCoursesAsync()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<IEnumerable<Course>> GetCoursesByPartAsync(string input)
        {
            var partName = input.Trim();
            var matches = await _context.Courses.Where(course => course.CourseName.Contains(partName)).ToListAsync();
            return matches;
        }


        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(CourseViewModel updatedCourse, int id)
        {
            var course = _mapper.Map<Course>(updatedCourse);
            course.Id = id;
            _context.Entry(course).State = EntityState.Modified;
        }

    }
}