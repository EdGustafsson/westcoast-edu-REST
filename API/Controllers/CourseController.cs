using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using API.ViewModels;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses(){
            return Ok(await _unitOfWork.CourseRepository.GetCoursesAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourseById(int id){
            return Ok(await _unitOfWork.CourseRepository.GetCourseByIdAsync(id));
        }

        [HttpGet("findnumber/{coursenumber}")]
        public async Task<ActionResult<Course>> GetCourseByCourseNumber(int courseNumber){


            try{
               
                var result = await _unitOfWork.CourseRepository.GetCourseByCourseNumberAsync(courseNumber);
                return StatusCode(200, result);
            }
            catch(Exception ex){
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("find/{query}")]
        public async Task<ActionResult<IEnumerable<Course>>> GetCoursesByQuery(string query){
            return Ok(await _unitOfWork.CourseRepository.GetCoursesByPartAsync(query));
        }

        [HttpPost()]
        public async Task<ActionResult> AddCourse(CourseViewModel model){
            _unitOfWork.CourseRepository.Add(model);
            if (await _unitOfWork.Complete())
            {
                return StatusCode(201);
            }

            return StatusCode(500, "Det gick inte att spara ner ny kurs");
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateCourse (int id, CourseViewModel updatedCourse){

            _unitOfWork.CourseRepository.Update(updatedCourse, id);
            if (await _unitOfWork.CourseRepository.SaveAllAsync()) return NoContent();

            return StatusCode(500, "Det gick inte att uppdatera kursen");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCourse(int id){
            var course = await _unitOfWork.CourseRepository.GetCourseByIdAsync(id);
            if(course == null) return NotFound($"Hittade ingen kurs med id: {id}");

            _unitOfWork.CourseRepository.Delete(course);
            if (await _unitOfWork.CourseRepository.SaveAllAsync()) return NoContent();

            return StatusCode(500, "Det gick inte att ta bort kursen");
        }
    }
}