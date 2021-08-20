using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using API.ViewModels;

namespace API.Interfaces
{
    public interface IUserCourseRepository
    {
        void Add(UserCourseViewModel UserCourse);
        Task<IEnumerable<UserCourse>> GetUserCoursesAsync();
    }
}