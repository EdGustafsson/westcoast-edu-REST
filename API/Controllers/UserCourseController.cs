using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using API.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/usercourse")]
    public class UserCourseController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserCourseController(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserCourse>>> GetUserCourses(){
            return Ok(await _unitOfWork.UserCourseRepository.GetUserCoursesAsync());
        }

        [HttpPost()]
        public async Task<ActionResult> AddUserCourseToCourse(UserCourseViewModel model){
            var user = await _unitOfWork.UserRepository.GetUserByIdAsync(model.UserId);
            if(user == null) return BadRequest($"Användaren kunde inte hittas");

            var course = await _unitOfWork.CourseRepository.GetCourseByIdAsync(model.CourseId);
            if(course == null) return BadRequest($"Kursen kunde inte hittas");

            _unitOfWork.UserCourseRepository.Add(model);

            if (await _unitOfWork.Complete())
            {
                return StatusCode(201);
            }

            return StatusCode(500, "Det gick inte att spara använvaden");
        }
    }
}