using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IUnitOfWork
    {
        ICourseRepository CourseRepository{get;}
        IUserCourseRepository UserCourseRepository{get;}
        IUserRepository UserRepository{get;}
        Task<bool> Complete();
        bool HasChanges();
    }
}