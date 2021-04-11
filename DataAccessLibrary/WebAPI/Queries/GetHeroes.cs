using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataAccessLibrary.Repositories;
using MediatR;

namespace WebAPI.Queries
{
    public static class GetHeroes
    {
        public record Query() : IRequest<List<HeroViewModel>>;
        public record HeroViewModel(string FirstName, string LastName);

        public class Handler : IRequestHandler<Query, List<HeroViewModel>>
        {
            private readonly IHeroRepository _heroRepository;

            public Handler(IHeroRepository heroRepository)
            {
                _heroRepository = heroRepository;
            }
            public async Task<List<HeroViewModel>> Handle(Query request, CancellationToken cancellationToken)
            {
                var heroes = await _heroRepository.GetHeroes();

                var heroesViewModel = heroes.Select(x => new HeroViewModel(x.FirstName, x.LastName));

                return heroesViewModel.ToList();
            }
        }
    }
    
    
}
