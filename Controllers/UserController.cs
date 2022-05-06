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

    }
}
