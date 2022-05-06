using DAWW.Interfaces;
using DAWW.Models;
using Microsoft.AspNetCore.Mvc;

namespace DAWW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController: Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
        public IActionResult GetUseri()
        {
            var useri = _userRepository.GetUseri();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(useri);
        }
        [HttpGet("{mail}")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(400)]
        public IActionResult GetUserByEmail(string mail)
        {
            if (!_userRepository.UserExists(mail))
                return NotFound();
            var user = _userRepository.GetUserByMail(mail);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(user);
        }

    }
}
