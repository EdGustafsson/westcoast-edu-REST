using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using API.ViewModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class UserCourseRepository : IUserCourseRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UserCourseRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<UserCourse>> GetUserCoursesAsync()
        {
            return await _context.UserCourses.ToListAsync();
        }
        public void Add(UserCourseViewModel userCourse)
        {
            var newUserCourse = _mapper.Map<UserCourse>(userCourse);
            _context.Entry(newUserCourse).State = EntityState.Added;
        }


        

    }
}