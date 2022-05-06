using AutoMapper;
using DAWW.Dto;
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
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;

         }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
        public IActionResult GetUseri()
        {
            var useri = _mapper.Map<List<UserDto>>(_userRepository.GetUseri());
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
            var user = _mapper.Map<UserDto>(_userRepository.GetUserByMail(mail));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(user);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateUser([FromBody] UserDto userCreat)
        {
            if (userCreat == null)
                return BadRequest(ModelState);

            var userExistent = _userRepository.GetUseri().Where(x=> x.Email == userCreat.Email).FirstOrDefault();
            if (userExistent != null)
            {
                ModelState.AddModelError("", "Userul deja exista");
                return StatusCode(422,ModelState);
            }

            var userMapat = _mapper.Map<User>(userCreat);
            if (!_userRepository.CreateUser(userMapat))
            {
                ModelState.AddModelError("", "Eroare");
                return StatusCode(500, ModelState);
            }

            return Ok();

        }

    }
}
