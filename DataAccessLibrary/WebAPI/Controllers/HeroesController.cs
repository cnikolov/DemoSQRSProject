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
    }
}
