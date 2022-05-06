using AutoMapper;
using DAWW.Dto;
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
        private readonly IMapper _mapper;

        public AchizitieController(IAchizitieRepository achizitieRepository, IMapper mapper)
        {
            _achizitieRepository = achizitieRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Achizitie>))]
        public IActionResult GetAchizitii()
        {
            var achizitii = _mapper.Map<List<AchizitieDto>>(_achizitieRepository.GetAchizitii());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(achizitii);
        }
        [HttpPost("adaugareAchizitie/u{user}&p{produs}&c{comanda}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateAchizitie([FromRoute] int user, [FromRoute] int produs, [FromRoute] int comanda)
        {
            

            var achizitieCreata = new Achizitie();
            achizitieCreata.IdUser = user;
            achizitieCreata.IdProdus = produs;
            achizitieCreata.IdComanda = comanda;

            if (achizitieCreata == null)
                return BadRequest(ModelState);

            var achizitieMapata = _mapper.Map<Achizitie>(achizitieCreata);
            if (!_achizitieRepository.CreateAchizitie(achizitieMapata))
            {
                ModelState.AddModelError("", "Eroare");
                return StatusCode(500, ModelState);
            }

            return Ok();

        }

    }
}
