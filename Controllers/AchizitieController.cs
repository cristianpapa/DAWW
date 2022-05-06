﻿using AutoMapper;
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

    }
}
