using Microsoft.AspNetCore.Mvc;
using UniversityAPI.Contracts;
using UniversityAPI.Models.DataModels;
using UniversityAPI.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UniversityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IServiceWrapper _service;
        private IUserService _userService;

        public UsersController(IServiceWrapper service)
        {
            _service = service;
            _userService = service.UserService;
        }
    
        // GET: api/<UsersController>
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            var users = _userService.GetAll();
            if (users == null || users.Count() < 1)
            {
                return NotFound();
            }
            return Ok(users);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            var user = _userService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        // POST api/<UsersController>
        [HttpPost]
        public ActionResult<User> PostUser(User user)
        {
            _userService.Add(user);
            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public ActionResult<User> PutUser(int id, User user)
        {
            _userService.Update(user);
            return CreatedAtAction("GetUser", new { id = user.Id }, user);

        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            _userService.Delete(id);
            return NoContent();
        }

        [HttpGet("{email}")]
        public ActionResult<IEnumerable<User>> GetUsers(string email)
        {
            var users = _userService.GetUsersByEmail(email);
            if (users == null || users.Count() < 1)
            {
                return NotFound();
            }
            return Ok(users);
        }
    }
}
