using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using API.Entities;
using System.Threading.Tasks;
using API.ViewModels;
using API.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers(){
            return Ok(await _unitOfWork.UserRepository.GetUsersAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id){
            return Ok(await _unitOfWork.UserRepository.GetUserByIdAsync(id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id){
            var user = await _unitOfWork.UserRepository.GetUserByIdAsync(id);

            if (user == null) return NotFound($"Hittade ingen användare med id: {id}");

            _unitOfWork.UserRepository.Delete(user);

            if (await _unitOfWork.UserRepository.SaveAllAsync()) return NoContent();
            return StatusCode(500, "Det gick inte att ta bort användaren");
        }

        [HttpPost()]
        public async Task<ActionResult> AddUser(UserViewModel model){
            _unitOfWork.UserRepository.Add(model);
            if (await _unitOfWork.Complete())
            {
                return StatusCode(201);
            }
            return StatusCode(500, "Det gick inte att spara ner ny användare");
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateUser (int id, UserViewModel updatedUser){

            _unitOfWork.UserRepository.Update(updatedUser, id);

            if (await _unitOfWork.UserRepository.SaveAllAsync()) return NoContent();
             return StatusCode(500, "Det gick inte att uppdatera användaren");
        }
    }
}