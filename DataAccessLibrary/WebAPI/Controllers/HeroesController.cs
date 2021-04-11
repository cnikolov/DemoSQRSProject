using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLibrary.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Queries;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HeroesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IEnumerable<GetHeroes.HeroViewModel>> Get()
        {
            var heroes = await _mediator.Send(new GetHeroes.Query());
            return heroes;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var hero = await _mediator.Send(new GetHeroById.Query(id));
            return hero == null ? NotFound() : Ok(hero);
        }
    }
}