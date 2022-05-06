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
        public ProdusController(IProdusRepository produsRepository)
        {
            _produsRepository = produsRepository;
        }
        [HttpGet]
        [ProducesResponseType(200,Type = typeof(IEnumerable<Produs>))]
        public IActionResult GetProduse()
        {
            var produse = _produsRepository.GetProduse();

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

            var produs = _produsRepository.GetProdusById(id);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(produs);
        }
        /*[HttpGet("{nume}")]
        [ProducesResponseType(200, Type = typeof(Produs))]
        [ProducesResponseType(400)]
        public IActionResult GetProdusByName(string nume)
        {
            //if (!_produsRepository.ProdusExists(nume))
               // return NotFound();

            var produs = _produsRepository.GetProdusByName(nume);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(produs);
        }*/



    }
}
