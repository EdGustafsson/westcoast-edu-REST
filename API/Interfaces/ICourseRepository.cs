using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using API.ViewModels;

namespace API.Interfaces
{
    public interface ICourseRepository
    {
        void Add(CourseViewModel user);
        Task<IEnumerable<Course>> GetCoursesAsync();
        Task<IEnumerable<Course>> GetCoursesByPartAsync(string input);
        Task<Course> GetCourseByCourseNumberAsync(int id); 
        Task<Course> GetCourseByIdAsync(int id);
        void Delete(Course course);
        Task<bool> SaveAllAsync();
        void Update(CourseViewModel updatedCourse, int id);
    }
}