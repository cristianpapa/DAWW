using DAWW.Interfaces;
using DAWW.Models;
using DAWW.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DAWW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AchizitieController : Controller
    {
        private readonly IAchizitieRepository _achizitieRepository;

        public AchizitieController(IAchizitieRepository achizitieRepository)
        {
            _achizitieRepository = achizitieRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Achizitie>))]
        public IActionResult GetAchizitii()
        {
            var achizitii = _achizitieRepository.GetAchizitii();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(achizitii);
        }

    }
}
