using Application.IServices;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TavelAgency.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }
     
        [Route("GetAllUsers")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetAll()
        {
            var students =  _service.Get();
            return Ok(students);
        }
        [Route("SaveUser")]
        [HttpPost]
        public async Task< ActionResult<Users>> SaveUser([FromBody] Users user)
        {
            _service.Create(user);
            return Ok(user);
        }

        [Route("UpdateUser")]
        [HttpPut]
        public ActionResult UpdateUser(string id, [FromBody] Users student)
        {
            var existingStudent = _service.Get(id);

            if (existingStudent == null)
            {
                return NotFound($"Student with Id = {id} not found");
            }

            _service.Update(id, student);

            return Ok(student);
        }
        [Route("DeleteUser")]
        [HttpDelete]
        public ActionResult DeleteUser(string id)
        {
            var student = _service.Get(id);

            if (student == null)
            {
                return NotFound($"Student with Id = {id} not found");
            }

            _service.Remove(student.Id);

            return Ok($"Student with Id = {id} deleted");
        }
    }
}
