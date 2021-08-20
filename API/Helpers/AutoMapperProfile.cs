using API.Entities;
using API.ViewModels;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserViewModel, User>();

            CreateMap<CourseViewModel, Course>();

            CreateMap<UserCourseViewModel, UserCourse>();

        }
    }
}