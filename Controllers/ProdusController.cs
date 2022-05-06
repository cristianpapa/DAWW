using AutoMapper;
using DAWW.Dto;
using DAWW.Interfaces;
using DAWW.Models;
using Microsoft.AspNetCore.Mvc;

namespace DAWW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdusController : Controller
    {
        private readonly IProdusRepository _produsRepository;
        private readonly IMapper _mapper;
        public ProdusController(IProdusRepository produsRepository, IMapper mapper)
        {
            _produsRepository = produsRepository;
            _mapper = mapper;   
        }
        [HttpGet]
        [ProducesResponseType(200,Type = typeof(IEnumerable<Produs>))]
        public IActionResult GetProduse()
        {
            var produse = _mapper.Map< List<ProdusDto> >(_produsRepository.GetProduse());

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(produse);
        }


        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Produs))]
        [ProducesResponseType(400)]
        public IActionResult GetProdusById(int id)
        {
            if (!_produsRepository.ProdusExists(id))
                return NotFound();

            var produs = _mapper.Map<ProdusDto>(_produsRepository.GetProdusById(id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(produs);
        }
    
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateProdus([FromBody] ProdusDto produsCreat)
        {
            if (produsCreat == null)
                return BadRequest(ModelState);

            var produsMapat = _mapper.Map<Produs>(produsCreat);
            if(!_produsRepository.CreateProdus(produsMapat))
            {
                ModelState.AddModelError("", "Eroare");
                return StatusCode(500, ModelState);
            }

            return Ok();
            
        }


    }
}
